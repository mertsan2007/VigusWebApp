using Vigus.Web.Data;

namespace Vigus.Web.Models
{
    public class HomeViewModel
    {
        public IQueryable<GpusViewModel>? GpuViewModel { get; set; }
        public IQueryable<DriverViewModel>? DriverViewModel { get; set; }
        public IQueryable<GpuTechnology>? TechnologyViewModel { get; set; }
    }
}
