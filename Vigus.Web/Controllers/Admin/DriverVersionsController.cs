using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;

namespace Vigus.Web.Controllers.Admin
{
    public class DriverVersionsController : Controller
    {
        private readonly VigusGpuContext _context;

        public DriverVersionsController(VigusGpuContext context)
        {
            _context = context;
        }

        // GET: DriverVersions
        public async Task<IActionResult> Index()
        {
              return _context.DriverVersions != null ? 
                          View(await _context.DriverVersions.ToListAsync()) :
                          Problem("Entity set 'VigusGpuContext.DriverVersions'  is null.");
        }

        // GET: DriverVersions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DriverVersions == null)
            {
                return NotFound();
            }

            var driverVersion = await _context.DriverVersions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverVersion == null)
            {
                return NotFound();
            }

            return View(driverVersion);
        }

        // GET: DriverVersions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DriverVersions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,KnownIssues,FixedChanges,Id")] DriverVersion driverVersion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driverVersion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driverVersion);
        }

        // GET: DriverVersions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DriverVersions == null)
            {
                return NotFound();
            }

            var driverVersion = await _context.DriverVersions.FindAsync(id);
            if (driverVersion == null)
            {
                return NotFound();
            }
            return View(driverVersion);
        }

        // POST: DriverVersions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,KnownIssues,FixedChanges,Id")] DriverVersion driverVersion)
        {
            if (id != driverVersion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driverVersion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverVersionExists(driverVersion.Id))
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
            return View(driverVersion);
        }

        // GET: DriverVersions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DriverVersions == null)
            {
                return NotFound();
            }

            var driverVersion = await _context.DriverVersions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (driverVersion == null)
            {
                return NotFound();
            }

            return View(driverVersion);
        }

        // POST: DriverVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DriverVersions == null)
            {
                return Problem("Entity set 'VigusGpuContext.DriverVersions'  is null.");
            }
            var driverVersion = await _context.DriverVersions.FindAsync(id);
            if (driverVersion != null)
            {
                _context.DriverVersions.Remove(driverVersion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverVersionExists(int id)
        {
          return (_context.DriverVersions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
