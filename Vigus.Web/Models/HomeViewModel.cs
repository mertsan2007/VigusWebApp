using Vigus.Web.Data;
using Vigus.Web.Models.Gpu;

namespace Vigus.Web.Models;

public class HomeViewModel
{
    public IQueryable<GpusViewModel>? GpuViewModel { get; set; }
    public IQueryable<DriverVersion>? DriverViewModel { get; set; }
    public IQueryable<GpuTechnology>? TechnologyViewModel { get; set; }
}