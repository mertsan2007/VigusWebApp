using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;
using Vigus.Web.Models;

namespace Vigus.Web.Controllers.Admin;

public class GpusController : Controller 
{
    private readonly VigusGpuContext _context;
    public IQueryable<Gpu> _gpu;
    public IQueryable<GpusViewModel> _gpudata;

    public GpusController(VigusGpuContext context)
    {
        _context = context;
        _gpu = _context.Gpus.Include(g => g.Model);
        _gpudata = from gpu in _gpu
                   orderby gpu.Id
            select new GpusViewModel
            {
                Id = gpu.Id,
                Cores = gpu.Cores,
                Description = gpu.Description != null ? gpu.Description : "not set",
                FullGpuName = $"Vigus {gpu.Name}",
                MemorySizeInGb = gpu.MemorySize + "GB",
                PriceInDollars = gpu.Price != null ? gpu.Price + "$" : "not set",
                ReleaseDate = gpu.ReleaseDate,
                TdpInWatts = gpu.Tdp + "W",
                ModelName = gpu.Model.Name,
                ImageName = gpu.Image.Name
            };
    }
    
    [HttpPost]
    public async Task<IActionResult> Filter(GpuFilterModel filterModel)
    {
        ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name");

        var gpus = _gpu
            .Include(z => z.Model.Series)
            .Where(it =>
                string.IsNullOrEmpty(filterModel.Name) || it.Name.Contains(filterModel.Name) ||
                (it.ModelId == filterModel.ModelId &&
                 it.MemorySize == filterModel.MemorySize)
            );

        var data = from gpu in gpus
            orderby gpu.Id
            select new GpusViewModel
            {
                Id = gpu.Id,
                Cores = gpu.Cores,
                Description = gpu.Description != null ? gpu.Description : "not set",
                FullGpuName = $"Vigus {gpu.Name}",
                MemorySizeInGb = gpu.MemorySize + "GB",
                PriceInDollars = gpu.Price != null ? gpu.Price + "$" : "not set",
                ReleaseDate = gpu.ReleaseDate,
                TdpInWatts = gpu.Tdp + "W",
                ModelName = gpu.Model.Name,
                ImageName = gpu.Image.Name
            };

        return View("Index", await data.ToListAsync());
    }

    public async Task<IActionResult> Index()
    {
        var data = _gpudata;

        ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name");
        return View(await data.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Gpus == null)
            return NotFound();

        var data = await _gpu
            .Include(g => g.Image)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (data == null)
            return NotFound();

        return View(data);
    }

    public IActionResult Create()
    {
        GpuCreateViewModel vm = new();
        ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name");
        ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name");
        ViewData["DriverId"] = new SelectList(_context.DriverVersions, "Id", "Name");
        
        vm.SelectListItems = _context.DriverVersions.Select(z => 
            new SelectListItem()
            {
                Text = z.Name, Value = z.Id.ToString()
            }).ToList();

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Name,Cores,Tdp,ReleaseDate,Price,MemorySize,Description,ModelId,ImageId,Id,SupportedDriverVersions")] Gpu gpu, List<int> selectedDriverIds)
    {
        if (ModelState.IsValid)
        {
            if (gpu.Name.Contains("Vigus") != true)
            {
                gpu.Name = "Vigus " + gpu.Name;
            }
            CreateDriverVersions(gpu.Id, selectedDriverIds);
            _context.Add(gpu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name", gpu.ModelId);
        ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name", gpu.ImageId);
        ViewData["DriverId"] = new SelectList(_context.DriverVersions, "Id", "Name", gpu.SupportedDriverVersions);
        return View(gpu);
    }
    
    public async Task CreateDriverVersions(int id, List<int> selectedDriverIds)
    {
        var gpu = await _context.Gpus.FindAsync(id);
        foreach (var driverId in selectedDriverIds)
        {
            var driver = new DriverVersion { Id = driverId };
            _context.DriverVersions.Attach(driver);
            gpu.SupportedDriverVersions.Add(driver);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Gpus == null)
            return NotFound();

        var gpu = await _context.Gpus.FindAsync(id);
        if (gpu == null)
            return NotFound();
        
        ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name", gpu.ModelId);
        ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name", gpu.ImageId);
        ViewData["DriverId"] = new SelectList(_context.DriverVersions, "Id", "Name", gpu.SupportedDriverVersions);
        return View(gpu);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("Name,Cores,Tdp,ReleaseDate,Price,MemorySize,Description,ModelId,ImageId,Id")] Gpu gpu)
    {
        if (id != gpu.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(gpu);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GpuExists(gpu.Id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Id", gpu.ModelId);
        ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name", gpu.ImageId);
        ViewData["DriverId"] = new SelectList(_context.DriverVersions, "Id", "Name", gpu.SupportedDriverVersions);
        return View(gpu);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Gpus == null)
            return NotFound();

        var gpu = await _context.Gpus
            .Include(g => g.Model)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (gpu == null)
            return NotFound();

        return View(gpu);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Gpus == null)
            return Problem("Entity set 'VigusGpuContext.Gpus'  is null.");
        
        var gpu = await _context.Gpus.FindAsync(id);
        if (gpu != null)
            _context.Gpus.Remove(gpu);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool GpuExists(int id)
    {
        return (_context.Gpus?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}