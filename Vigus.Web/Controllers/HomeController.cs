using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;

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
            return View(await vigusGpuContext.ToListAsync());
        }
    }
}
