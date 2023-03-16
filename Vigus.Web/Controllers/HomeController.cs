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

        public async Task<IActionResult> Index()
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
                    ModelName = gpu.Model.Name
                };
            return View(await vigusGpuContext.ToListAsync());
        }
    }
}
