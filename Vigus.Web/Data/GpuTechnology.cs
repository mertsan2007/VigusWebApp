namespace Vigus.Web.Data;

public class GpuTechnology : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public virtual List<GpuModel>? GpuModels { get; set; }
    // hd decode-encode support, directx12 support
}