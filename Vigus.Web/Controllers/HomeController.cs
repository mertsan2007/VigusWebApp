using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vigus.Web.Data;
using Vigus.Web.Models;
using Vigus.Web.Models.Gpu;

namespace Vigus.Web.Controllers;

public class HomeController : Controller
{
    private readonly VigusGpuContext _context;
    private readonly IQueryable<GpusViewModel> _gpudata;
    private readonly IQueryable<Series> _seriesdata;
    private readonly IQueryable<GpuTechnology> _technologydata;
    public HomeViewModel vm = new();

    public HomeController(VigusGpuContext context)
    {
        _context = context;
        _gpudata = from gpu in _context.Gpus.Include(g => g.Model)
                   orderby gpu.Name
                   select new GpusViewModel
                   {
                       Id = gpu.Id,
                       Cores = gpu.Cores,
                       Description = gpu.Description,
                       FullGpuName = gpu.Name.Contains("Vigus") ? gpu.Name : "Vigus " + gpu.Name,
                       MemorySizeInGb = gpu.MemorySize + "GB",
                       PriceInDollars = gpu.Price + "$",
                       ReleaseDate = gpu.ReleaseDate,
                       TdpInWatts = gpu.Tdp + "W",
                       ModelName = gpu.Model.Name,
                       ImageName = gpu.Image.Name
                   };
        _technologydata = _context.GpuTechnologies.Include(t => t.Image).OrderByDescending(x => x.Id);
        _seriesdata = _context.Series.OrderByDescending(s => s.Name);
    }

    public async Task<IActionResult> Index()
    {
        vm.GpuViewModel = _gpudata;
        vm.TechnologyViewModel = _technologydata;
        return View(vm);
    }

    public async Task<IActionResult> Products()
    {
        vm.GpuViewModel = _gpudata;
        return View(vm);
    }

    public async Task<IActionResult> GetGpu(int? id)
    {
        if (id == null || _context.Gpus == null || id == 0)
        {
            return Json("request is null");
        }
        else
        {
            var gpuModel = await _context.GpuModels.FindAsync(id);

            var gpus = gpuModel.Gpus
                .Select(g => new { g.Id, g.Name });
            return Json(gpus);
        }
    }

    public IActionResult Support()
    {
        SupportViewModel svm = new()
        {
            SeriesVm = _seriesdata,
            TechnologyViewModel = _technologydata
        };

        ViewData["ModelId"] = new SelectList(_context.GpuModels.OrderByDescending(z => z.Name), "Id", "Name");
        return View(svm);
    }

    [HttpPost]
    public async Task<IActionResult> Support(SupportViewModel svm)
    {
        if (svm.SelectedItems == null || svm.SelectedItems.Any() == false)
        {
            return NotFound();
        }
        else
        {
            foreach (var gpuId in svm.SelectedItems)
            {
                var foundGpu = await _context.Gpus.FindAsync(gpuId);

                if (foundGpu == null || gpuId == 0 || foundGpu.SupportedDriverVersions == null || foundGpu.SupportedDriverVersions.Count <= 0)
                {
                    break;
                }
                else
                {
                    svm.SelectListItems = new List<SelectListItem>();
                    foreach (var driver in foundGpu.SupportedDriverVersions)
                    {
                        svm.SelectListItems.Add(new SelectListItem
                        {
                            Text = "Vigus Driver Version " + driver.Name,
                            Value = driver.Id.ToString()
                        });
                    }
                }
            }
        }
        svm.SeriesVm = _seriesdata;
        svm.TechnologyViewModel = _technologydata;

        ViewData["OsId"] = new SelectList(_context.OsVersions, "Id", "Name");
        return View(svm);
    }
}