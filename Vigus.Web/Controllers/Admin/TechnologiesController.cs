using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;

namespace Vigus.Web.Controllers.Admin
{
    public class TechnologiesController : Controller
    {
        private readonly VigusGpuContext _context;

        public TechnologiesController(VigusGpuContext context)
        {
            _context = context;
        }

        // GET: Technologies
        public async Task<IActionResult> Index()
        {
            var vigusGpuContext = _context.GpuTechnologies.Include(g => g.Image);
            return View(await vigusGpuContext.ToListAsync());
        }

        // GET: Technologies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GpuTechnologies == null)
            {
                return NotFound();
            }

            var gpuTechnology = await _context.GpuTechnologies
                .Include(g => g.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gpuTechnology == null)
            {
                return NotFound();
            }

            return View(gpuTechnology);
        }

        // GET: Technologies/Create
        public IActionResult Create()
        {
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Title");
            return View();
        }

        // POST: Technologies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ImageId,Id")] GpuTechnology gpuTechnology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gpuTechnology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Title", gpuTechnology.ImageId);
            return View(gpuTechnology);
        }

        // GET: Technologies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GpuTechnologies == null)
            {
                return NotFound();
            }

            var gpuTechnology = await _context.GpuTechnologies.FindAsync(id);
            if (gpuTechnology == null)
            {
                return NotFound();
            }
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Title", gpuTechnology.ImageId);
            return View(gpuTechnology);
        }

        // POST: Technologies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,ImageId,Id")] GpuTechnology gpuTechnology)
        {
            if (id != gpuTechnology.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gpuTechnology);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GpuTechnologyExists(gpuTechnology.Id))
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
            ViewData["ImageId"] = new SelectList(_context.Images, "Id", "Title", gpuTechnology.ImageId);
            return View(gpuTechnology);
        }

        // GET: Technologies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GpuTechnologies == null)
            {
                return NotFound();
            }

            var gpuTechnology = await _context.GpuTechnologies
                .Include(g => g.Image)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gpuTechnology == null)
            {
                return NotFound();
            }

            return View(gpuTechnology);
        }

        // POST: Technologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GpuTechnologies == null)
            {
                return Problem("Entity set 'VigusGpuContext.GpuTechnologies'  is null.");
            }
            var gpuTechnology = await _context.GpuTechnologies.FindAsync(id);
            if (gpuTechnology != null)
            {
                _context.GpuTechnologies.Remove(gpuTechnology);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GpuTechnologyExists(int id)
        {
            return (_context.GpuTechnologies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
