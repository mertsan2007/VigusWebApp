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
    public class GpuImagesController : Controller
    {
        private readonly VigusGpuContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GpuImagesController(VigusGpuContext context, IWebHostEnvironment hostEnvironment)
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

            var gpuImage = await _context.Images
                .Include(g => g.Gpus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gpuImage == null)
            {
                return NotFound();
            }

            return View(gpuImage);
        }

        // GET: GpuImages/Create
        public IActionResult Create()
        {
            ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Name");
            return View();
        }

        // POST: GpuImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,File,GpuId,Id")] Image gpuImage)
        {
            if (ModelState.IsValid)
            {
                string rootPath = _hostEnvironment.WebRootPath;
                gpuImage.Name = Path.GetFileName(gpuImage.File.FileName);

                string path = Path.Combine(rootPath + "/Images/UserUploads",gpuImage.Name);
                using (var filestream=new FileStream(path,FileMode.Create))
                {
                    await gpuImage.File.CopyToAsync(filestream);
                }

                _context.Add(gpuImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Name", gpuImage.Gpus);
            return View(gpuImage);
        }

        // GET: GpuImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var gpuImage = await _context.Images.FindAsync(id);
            if (gpuImage == null)
            {
                return NotFound();
            }
            ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Id", gpuImage.Gpus);
            return View(gpuImage);
        }

        // POST: GpuImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Name,GpuId,Id")] Image gpuImage)
        {
            if (id != gpuImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gpuImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GpuImageExists(gpuImage.Id))
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
            ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Id", gpuImage.Gpus);
            return View(gpuImage);
        }

        // GET: GpuImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Images == null)
            {
                return NotFound();
            }

            var gpuImage = await _context.Images
                .Include(g => g.Gpus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gpuImage == null)
            {
                return NotFound();
            }

            return View(gpuImage);
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
            var gpuImage = await _context.Images.FindAsync(id);
            var imgpath = Path.Combine(_hostEnvironment.WebRootPath, "Images/UserUploads", gpuImage.Name);
            if (gpuImage != null)
            {
                if(System.IO.File.Exists(imgpath))
                {System.IO.File.Delete(imgpath); }
                _context.Images.Remove(gpuImage);
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
