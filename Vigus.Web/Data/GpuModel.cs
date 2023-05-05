namespace Vigus.Web.Data;

public class GpuModel : EntityBase
{
    public string? Name { get; set; }

    public virtual ICollection<Gpu>? Gpus { get; set; }

    public int SeriesId { get; set; }
    public virtual Series? Series { get; set; }

    public virtual ICollection<GpuTechnology>? GpuTechnologies { get; set; }
}