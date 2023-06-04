using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Vigus.Web.Data;

namespace Vigus.Web.Controllers.Admin;

public class DriverVersionsController : Controller
{
    private readonly VigusGpuContext _context;

    public DriverVersionsController(VigusGpuContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return _context.DriverVersions != null
            ? View(await _context.DriverVersions.ToListAsync())
            : Problem("Entity set 'VigusGpuContext.DriverVersions'  is null.");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.DriverVersions == null) return NotFound();

        var driverVersion = await _context.DriverVersions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (driverVersion == null) return NotFound();

        return View(driverVersion);
    }

    public IActionResult Create()
    {
        //dv.SelectListItems = _context.OsVersions.Select(x =>
        //    new SelectListItem
        //    {
        //        Text = x.Name,
        //        Value = x.Id.ToString()
        //    }).ToList();
        ViewData["OsId"] = new SelectList(_context.OsVersions, "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Name,Description,KnownIssues,FixedChanges,Id,OsVersions")] DriverVersion driverVersion)
    {
        if (ModelState.IsValid)
        {

            _context.Add(driverVersion);
            await _context.SaveChangesAsync();

            if (driverVersion.SelectedItems != null || driverVersion.SelectedItems.Any())
            {
                var dversion = await _context.DriverVersions.FindAsync(driverVersion.Id);
                foreach (var osId in driverVersion.SelectedItems)
                {
                    var os = new OsVersion { Id = osId };
                    _context.OsVersions.Attach(os);
                    dversion.OsVersions.Add(os);
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        return View(driverVersion);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.DriverVersions == null) return NotFound();

        var driverVersion = await _context.DriverVersions.FindAsync(id);
        if (driverVersion == null) return NotFound();
        return View(driverVersion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("Name,Description,KnownIssues,FixedChanges,Id")] DriverVersion driverVersion)
    {
        if (id != driverVersion.Id) return NotFound();

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
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(driverVersion);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.DriverVersions == null) return NotFound();

        var driverVersion = await _context.DriverVersions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (driverVersion == null) return NotFound();

        return View(driverVersion);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.DriverVersions == null) return Problem("Entity set 'VigusGpuContext.DriverVersions'  is null.");
        var driverVersion = await _context.DriverVersions.FindAsync(id);
        if (driverVersion != null) _context.DriverVersions.Remove(driverVersion);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DriverVersionExists(int id)
    {
        return (_context.DriverVersions?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}