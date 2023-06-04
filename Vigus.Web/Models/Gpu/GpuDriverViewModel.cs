using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vigus.Web.Models.Gpu
{
    public class GpuDriverViewModel : Data.Gpu
    {
        public int[]? SelectedItems { get; set; }
    }
}
