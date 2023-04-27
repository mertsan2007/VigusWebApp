    using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;
using Vigus.Web.Models;

namespace Vigus.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly VigusGpuContext _context;

        public HomeController(VigusGpuContext context)
        {
            _context = context;
        }

        public HomeViewModel vm = new();
        public async Task<IActionResult> Index()
        {
            var vigusGpu = _context.Gpus.Include(g => g.Model);
            var vigusTechnology = _context.GpuTechnologies.Include(t => t.GpuModels);
            var gpuviewdata = from gpu in vigusGpu
                              orderby gpu.Id descending
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
            vm.GpuViewModel = gpuviewdata;
            vm.DriverViewModel = null;
            vm.TechnologyViewModel = vigusTechnology.OrderByDescending(x => x.Id);
            return View(vm);
        }
        public async Task<IActionResult> Products()
        {
            var vigusGpuContext = _context.Gpus.Include(g => g.Model);
            var data = from gpu in vigusGpuContext
                       orderby gpu.Id descending
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
            vm.GpuViewModel = data;
            vm.TechnologyViewModel = null;
            vm.DriverViewModel = null;
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> GetGpu(int modelId)
        {
            var gpuList = _context.GpuModels.Where(m => m.Id == modelId).FirstOrDefault().Gpus
                .Select(g => new { g.Id, Name = g.Name }).ToList();
            return Json(gpuList);
        }

        [HttpGet]
        public IActionResult Support()
        {
            SupportViewModel svm = new();
            
            //var gpucontext = _context.Gpus.Include(g => g.Model);
            //var gpumodel = _context.GpuModels.Include(m => m.Series);
            var gpuseries = _context.Series.OrderByDescending(s=>s.Name);
            //
            //var gpudata = from gpu in gpucontext
            //              orderby gpu.Id descending
            //              select new GpusViewModel
            //              {
            //                  Id = gpu.Id,
            //                  Cores = gpu.Cores,
            //                  Description = gpu.Description,
            //                  FullGpuName = $"Vigus {gpu.Name}",
            //                  MemorySizeInGb = gpu.MemorySize + "GB",
            //                  PriceInDollars = gpu.Price + "$",
            //                  ReleaseDate = gpu.ReleaseDate,
            //                  TdpInWatts = gpu.Tdp + "W",
            //                  ModelName = gpu.Model.Name,
            //                  ImageName = gpu.Image.Name
            //              };
            //
            //vm.GpuViewModel = gpudata;
            //
            //svm.HomeVm = vm;
            svm.SeriesVm = gpuseries;
            //svm.GpuModelVm = gpumodel;
            
            ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name");
            //ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Name");
            return View(svm);
        }

        [HttpPost]
        public IActionResult Support(SupportViewModel svm)
        {
            var gpudriver = _context.DriverVersions.Include(d => d.OsVersions);
            var gpucontext = _context.Gpus.Include(g => g.Model);
            var gpumodel = _context.GpuModels.Include(m => m.Series);
            var gpuseries = _context.Series.OrderByDescending(s => s.Name);

            var gpudata = from gpu in gpucontext
                          orderby gpu.Id descending
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

            var driverdata = from driver in gpudriver
                             select new DriverViewModel
                             {
                                 Id = driver.Id,
                                 Name = "Vigus Driver Software " + driver.Name,
                                 Description = driver.Description,
                                 FixedChanges = driver.FixedChanges,
                                 Gpus = driver.Gpus,
                                 KnownIssues = driver.KnownIssues,
                                 OsVersions = driver.OsVersions
                             };

            vm.GpuViewModel = gpudata;
            vm.TechnologyViewModel = null;
            vm.DriverViewModel = driverdata;

            svm.HomeVm = vm;
            svm.SeriesVm = gpuseries;
            svm.GpuModelVm = gpumodel;

            ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name");
            ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Name");
            ViewData["DriverId"] = new SelectList(_context.DriverVersions, "Id", "Name");
            ViewData["OsId"] = new SelectList(_context.OsVersions, "Id", "Name");
            return View(svm);
        }
    }
}
