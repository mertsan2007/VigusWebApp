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
        private readonly IQueryable<GpusViewModel> _gpudata;

        public HomeController(VigusGpuContext context)
        {
            _context = context;
            _gpudata = from gpu in _context.Gpus.Include(g => g.Model)
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
        }

        public HomeViewModel vm = new();
        public async Task<IActionResult> Index()
        {
            var vigusTechnology = _context.GpuTechnologies.Include(t => t.GpuModels);

            vm.GpuViewModel = _gpudata;
            vm.DriverViewModel = null;
            vm.TechnologyViewModel = vigusTechnology.OrderByDescending(x => x.Id);
            return View(vm);
        }
        public async Task<IActionResult> Products()
        {
            vm.GpuViewModel = _gpudata;
            return View(vm);
        }

        public async Task<IActionResult> GetGpu(int modelId)
        {
            var gpuList = _context.GpuModels.Where(m => m.Id == modelId).FirstOrDefault().Gpus
                .Select(g => new { g.Id, Name = g.Name }).ToList();
            return Json(gpuList);
        }

        [HttpGet]
        public IActionResult Support()
        {
            var gputechnology = _context.GpuTechnologies.Include(x => x.Image);
            var gpuseries = _context.Series.OrderByDescending(s => s.Name);

            SupportViewModel svm = new()
            {
                SeriesVm = gpuseries,
                TechnologyViewModel = gputechnology
            };

            ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name");
            return View(svm);
        }

        [HttpPost]
        public IActionResult Support(SupportViewModel svm)
        {
            var gpuseries = _context.Series.OrderByDescending(s => s.Name);
            var gputechnology = _context.GpuTechnologies.Include(x => x.Image);
            var driverdata = from driver in _context.DriverVersions
                             select new DriverVersion
                             {
                                 Name = "Vigus Driver Software " + driver.Name
                             };

            svm.GpuViewModel = _gpudata;
            svm.DriverViewModel = driverdata;
            svm.SeriesVm = gpuseries;
            svm.GpuModelVm = _context.GpuModels;
            svm.TechnologyViewModel = gputechnology;

            ViewData["ModelId"] = new SelectList(_context.GpuModels, "Id", "Name");
            ViewData["GpuId"] = new SelectList(_context.Gpus, "Id", "Name");
            ViewData["DriverId"] = new SelectList(_context.DriverVersions, "Id", "Name");
            ViewData["OsId"] = new SelectList(_context.OsVersions, "Id", "Name");
            return View(svm);
        }

    }
}
