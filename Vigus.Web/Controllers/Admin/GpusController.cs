using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;
using Vigus.Web.Models;

namespace Vigus.Web.Controllers.Admin
{
    public class GpusController : Controller
    {
        private readonly VigusGpuContext _context;

        public GpusController(VigusGpuContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Filter(GpuFilterModel filterModel)
        {
            ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name");

            var gpus = _context.Gpus.Include(g => g.Model)
                .Where(it =>
                    (String.IsNullOrEmpty(filterModel.Name) || it.Name.Contains(filterModel.Name)) &&
                    it.ModelId == filterModel.ModelId &&
                    it.MemorySize == filterModel.MemorySize

                );

            var data = from gpu in gpus
                       orderby gpu.Name
                       select new GpusViewModel
                       {
                           Id = gpu.Id
                           //Cores = gpu.Cores,
                           //Description = gpu.Description,
                           //FullGpuName = $"Vigus {gpu.Name}",
                           //MemorySizeInGb = gpu.MemorySize + "GB",
                           //PriceInDollars = gpu.Price + "$",
                           //ReleaseDate = gpu.ReleaseDate,
                           //TdpInWatts = gpu.Tdp + "W",
                           //ModelName = gpu.Model.Name
                       };

            return View("Index", await data.ToListAsync());
        }

        // GET: Gpus
        public async Task<IActionResult> Index()
        {
            var data = from gpu in _context.Gpus.Include(g => g.Model)
                       orderby gpu.Name
                       select new GpusViewModel
                       {
                           Id = gpu.Id,
                           Cores = gpu.Cores,
                           Description = gpu.Description,
                           FullGpuName = $"Vigus {gpu.Name}",
                           MemorySizeInGb = gpu.MemorySize + "GB",
                           PriceInDollars = gpu.Price + "$",
                           ReleaseDate = gpu.ReleaseDate,
                           TdpInWatts = gpu.Tdp + "W",
                           ModelName = gpu.Model.Name,
                           ImageName = gpu.Image.Name
                       };
            return View(await data.ToListAsync());
        }

        // GET: Gpus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gpus == null)
            {
                return NotFound();
            }

            var data =await _context.Gpus.Include(g => g.Model).FirstOrDefaultAsync(m => m.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // GET: Gpus/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name");
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name");
            ViewData["DriverId"] = new SelectList(_context.DriverVersions, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Cores,Tdp,ReleaseDate,Price,MemorySize,Description,ModelId,ImageId,Id")] Gpu gpu, GpuCreateViewModel vm)
        {
            vm.Id = gpu.Id;
            vm.Name = gpu.Name;
            vm.Description = gpu.Description;
            vm.Cores = gpu.Cores;
            vm.MemorySize = gpu.MemorySize;
            vm.Tdp = gpu.Tdp;
            vm.ImageId = gpu.ImageId;
            vm.ModelId = gpu.ModelId;
            vm.Price = gpu.Price;
            vm.ReleaseDate = gpu.ReleaseDate;
            vm.SupportedDriverVersions = gpu.SupportedDriverVersions;
            if (ModelState.IsValid)
            {
                _context.Add(gpu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name", gpu.ModelId);
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name", gpu.ImageId);
            ViewData["DriverId"] = new SelectList(_context.DriverVersions, "Id", "Name", gpu.SupportedDriverVersions);
            return View(vm);
        }
        // GET: Gpus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gpus == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpus.FindAsync(id);
            if (gpu == null)
            {
                return NotFound();
            }
            ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name", gpu.ModelId);
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name", gpu.ImageId);
            ViewData["DriverId"] = new SelectList(_context.DriverVersions, "Id", "Name", gpu.SupportedDriverVersions);
            return View(gpu);
        }

        // POST: Gpus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Cores,Tdp,ReleaseDate,Price,MemorySize,Description,ModelId,ImageId,Id")] Gpu gpu)
        {
            if (id != gpu.Id)
            {
                return NotFound();
            }

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
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Id", gpu.ModelId);
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Name", gpu.ImageId);
            ViewData["DriverId"] = new SelectList(_context.DriverVersions, "Id", "Name", gpu.SupportedDriverVersions);
            return View(gpu);
        }

        // GET: Gpus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gpus == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpus
                .Include(g => g.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gpu == null)
            {
                return NotFound();
            }

            return View(gpu);
        }

        // POST: Gpus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gpus == null)
            {
                return Problem("Entity set 'VigusGpuContext.Gpus'  is null.");
            }
            var gpu = await _context.Gpus.FindAsync(id);
            if (gpu != null)
            {
                _context.Gpus.Remove(gpu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GpuExists(int id)
        {
            return (_context.Gpus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
