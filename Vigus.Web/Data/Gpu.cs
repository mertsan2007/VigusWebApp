﻿namespace Vigus.Web.Data;

public class Gpu : EntityBase
{
    public string? Name { get; set; }
    public int? Cores { get; set; }
    public int Tdp { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal? Price { get; set; }
    public int MemorySize { get; set; }
    public string? Description { get; set; }

    public int ModelId { get; set; }
    public virtual GpuModel? Model { get; set; }

    public virtual ICollection<DriverVersion>? SupportedDriverVersions { get; set; }

    public virtual ICollection<GpuImage>? Images { get; set; }
}