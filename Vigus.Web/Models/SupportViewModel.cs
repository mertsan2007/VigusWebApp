using Vigus.Web.Data;

namespace Vigus.Web.Models
{
    public class SupportViewModel
    {
        public HomeViewModel? HomeVm { get; set; }
        public IQueryable<GpuModel>? GpuModelVm { get; set; }
        public IQueryable<Series>? SeriesVm { get; set; }
    }
}
