namespace Vigus.Web.Data;

public class Series : EntityBase
{
    public string? Name { get; set; }

    public virtual List<GpuModel>? GpuModels { get; set; }
    //C, B, A
}