using Microsoft.AspNetCore.Mvc.Rendering;
using Vigus.Web.Data;

namespace Vigus.Web.Models;

public class SupportViewModel : HomeViewModel
{
    public IQueryable<Data.GpuModel>? GpuModelVm { get; set; }
    public IQueryable<Series>? SeriesVm { get; set; }
    public int[]? SelectedItems { get; set; }
    public List<SelectListItem>? SelectListItems { get; set; }
}