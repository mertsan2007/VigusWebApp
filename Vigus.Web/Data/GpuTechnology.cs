﻿namespace Vigus.Web.Data;

public class GpuTechnology : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<GpuModel>? GpuModels { get; set; }

    public int? ImageId { get; set; }
    public virtual Image? Image { get; set; }
    // hd decode-encode support, directx12 support
}