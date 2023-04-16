using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Support()
        {
            var gpudriver = _context.DriverVersions.Include(d => d.OsVersions);
            return View(await gpudriver.ToListAsync());
        }
    }
}
