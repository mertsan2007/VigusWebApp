using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vigus.Web.Models.GpuModel
{
    public class GpuModelCreateVm : Data.GpuModel
    {
        public int[]? SelectedItems { get; set; }
    }
}
