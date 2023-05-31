using Microsoft.AspNetCore.Mvc.Rendering;
using Vigus.Web.Data;

namespace Vigus.Web.Models
{
    public class GpuCreateViewModel:Gpu
    {
        public List<SelectListItem>? SelectListItems { get; set; }
        public string[]? SelectedItems { get; set; }
    }
}
