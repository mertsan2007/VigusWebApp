namespace Vigus.Web.Data;

public class GpuModel : EntityBase
{
    public string? Name { get; set; }

    public virtual List<Gpu>? Gpus { get; set; }

    public int SeriesId { get; set; }
    public virtual Series? Series { get; set; }

    public virtual List<GpuTechnology>? GpuTechnologies { get; set; }
    //C 900 Series,C 800 Series
}