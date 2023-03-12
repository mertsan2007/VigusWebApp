using Microsoft.AspNetCore.Mvc;

namespace Vigus.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
