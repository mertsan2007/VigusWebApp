using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;

namespace Vigus.Web.Controllers.Admin
{
    public class GpuModelsController : Controller
    {
        private readonly VigusGpuContext _context;

        public GpuModelsController(VigusGpuContext context)
        {
            _context = context;
        }

        // GET: GpuModels
        public async Task<IActionResult> Index()
        {
            var vigusGpuContext = _context.GpuModels.Include(g => g.Series);
            return View(await vigusGpuContext.ToListAsync());
        }

        // GET: GpuModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GpuModels == null)
            {
                return NotFound();
            }

            var gpuModel = await _context.GpuModels
                .Include(g => g.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gpuModel == null)
            {
                return NotFound();
            }

            return View(gpuModel);
        }

        // GET: GpuModels/Create
        public IActionResult Create()
        {
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Id");
            return View();
        }

        // POST: GpuModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,SeriesId,Id")] GpuModel gpuModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gpuModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Id", gpuModel.SeriesId);
            return View(gpuModel);
        }

        // GET: GpuModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GpuModels == null)
            {
                return NotFound();
            }

            var gpuModel = await _context.GpuModels.FindAsync(id);
            if (gpuModel == null)
            {
                return NotFound();
            }
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Id", gpuModel.SeriesId);
            return View(gpuModel);
        }

        // POST: GpuModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,SeriesId,Id")] GpuModel gpuModel)
        {
            if (id != gpuModel.Id)
            {
                return NotFound();
            }

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
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "Id", gpuModel.SeriesId);
            return View(gpuModel);
        }

        // GET: GpuModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GpuModels == null)
            {
                return NotFound();
            }

            var gpuModel = await _context.GpuModels
                .Include(g => g.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gpuModel == null)
            {
                return NotFound();
            }

            return View(gpuModel);
        }

        // POST: GpuModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GpuModels == null)
            {
                return Problem("Entity set 'VigusGpuContext.GpuModels'  is null.");
            }
            var gpuModel = await _context.GpuModels.FindAsync(id);
            if (gpuModel != null)
            {
                _context.GpuModels.Remove(gpuModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GpuModelExists(int id)
        {
          return (_context.GpuModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
