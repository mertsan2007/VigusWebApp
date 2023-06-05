using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;
using Vigus.Web.Models.GpuModel;

namespace Vigus.Web.Controllers.Admin;

public class GpuModelsController : Controller
{
    private readonly VigusGpuContext _context;

    public GpuModelsController(VigusGpuContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var vigusGpuContext = _context.GpuModels.Include(g => g.Series);
        return View(await vigusGpuContext.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.GpuModels == null) return NotFound();

        var gpuModel = await _context.GpuModels
            .Include(g => g.Series)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (gpuModel == null) return NotFound();

        return View(gpuModel);
    }

    public IActionResult Create()
    {
        ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Name");
        ViewData["TechnologyId"] = new SelectList(_context.GpuTechnologies, "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,SeriesId,Id,GpuTechnologies")] GpuModel gpuModel, GpuModelCreateVm gcm)
    {
        if (ModelState.IsValid)
        {
            if (gpuModel.Name.Contains("Serisi") || gpuModel.Name.Contains("Series") == false)
            {
                gpuModel.Name = gpuModel.Name + " Serisi";
            }

            _context.Add(gpuModel);
            await _context.SaveChangesAsync();
            if (gcm.SelectedItems != null && gcm.SelectedItems.Any())
            {
                var gmodel = await _context.GpuModels.FindAsync(gpuModel.Id);
                foreach (var technologyId in gcm.SelectedItems)
                {
                    var technology = new GpuTechnology { Id = technologyId};
                    _context.GpuTechnologies.Attach(technology);
                    gmodel.GpuTechnologies.Add(technology);
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Id", gpuModel.SeriesId);
        return View(gpuModel);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.GpuModels == null) return NotFound();

        var gpuModel = await _context.GpuModels.FindAsync(id);
        if (gpuModel == null) return NotFound();
        ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Id", gpuModel.SeriesId);
        return View(gpuModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Name,SeriesId,Id")] GpuModel gpuModel)
    {
        if (id != gpuModel.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(gpuModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GpuModelExists(gpuModel.Id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Name", gpuModel.SeriesId);
        return View(gpuModel);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.GpuModels == null) return NotFound();

        var gpuModel = await _context.GpuModels
            .Include(g => g.Series)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (gpuModel == null) return NotFound();

        return View(gpuModel);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.GpuModels == null) return Problem("Entity set 'VigusGpuContext.GpuModels'  is null.");
        var gpuModel = await _context.GpuModels.FindAsync(id);
        if (gpuModel != null) _context.GpuModels.Remove(gpuModel);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool GpuModelExists(int id)
    {
        return (_context.GpuModels?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}