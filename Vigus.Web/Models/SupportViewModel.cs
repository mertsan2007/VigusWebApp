using Vigus.Web.Data;

namespace Vigus.Web.Models
{
    public class SupportViewModel : HomeViewModel
    {
        public IQueryable<GpuModel>? GpuModelVm { get; set; }
        public IQueryable<Series>? SeriesVm { get; set; }
    }
}
