using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;

namespace Vigus.Web.Controllers.Admin
{
    public class ImagesController : Controller
    {
        private readonly VigusGpuContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImagesController(VigusGpuContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: GpuImages
        public async Task<IActionResult> Index()
        {
            var vigusGpuContext = _context.Images.Include(g => g.Gpus);
            return View(await vigusGpuContext.ToListAsync());
        }

        // GET: GpuImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .Include(g => g.Gpus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: GpuImages/Create
        public IActionResult Create()
        {
            ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Name");
            ViewData["TechnologyId"] = new SelectList(_context.GpuTechnologies, "Id", "Name");
            return View();
        }

        // POST: GpuImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,File,Gpus,Technologies,Id")] Image image)
        {
            if (ModelState.IsValid)
            {
                string rootPath = _hostEnvironment.WebRootPath;
                image.Name = Path.GetFileName(image.File.FileName);

                string path = Path.Combine(rootPath + "/Images/UserUploads", image.Name);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await image.File.CopyToAsync(filestream);
                }

                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Name", image.Gpus);
            ViewData["TechnologyId"] = new SelectList(_context.GpuTechnologies, "Id", "Name", image.Technologies);
            return View(image);
        }

        // GET: GpuImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Id", image.Gpus);
            return View(image);
        }

        // POST: GpuImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Name,GpuId,Id")] Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GpuImageExists(image.Id))
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
            ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Id", image.Gpus);
            return View(image);
        }

        // GET: GpuImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .Include(g => g.Gpus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: GpuImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Images == null)
            {
                return Problem("Entity set 'VigusGpuContext.GpuImages'  is null.");
            }
            var image = await _context.Images.FindAsync(id);
            var imgpath = Path.Combine(_hostEnvironment.WebRootPath, "Images/UserUploads", image.Name);
            if (image != null)
            {
                if (System.IO.File.Exists(imgpath))
                { System.IO.File.Delete(imgpath); }
                _context.Images.Remove(image);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GpuImageExists(int id)
        {
            return (_context.Images?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
