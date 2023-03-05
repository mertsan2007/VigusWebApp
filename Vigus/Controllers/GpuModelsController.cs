using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Vigus.Controllers
{
    public class GpuModelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
