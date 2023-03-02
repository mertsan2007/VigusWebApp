using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vigus.data.Data
{
    public class EntityBase
    {
        public int Id { get; set; }
    }
    public class Gpu:EntityBase
    {
        public string? Name { get; set; }
        public int? Cores { get; set; }
        public int Tdp { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal? Price { get; set; }
        public int MemorySize { get; set; }
        
        public int ModelId { get; set; }
        public virtual Model? Model { get; set; }
        
        public int SeriesId { get; set; }
        public virtual Series? Series { get; set; }
        
        
        public List<double>? DriverVersion { get; set; }
    }
    public class Series:EntityBase
    {
        public string? Name { get; set; }
    }
    public class Model : EntityBase
    {
        public string? Name { get; set; }
        public int SeriesId { get; set; }
    }
    public class GpuTechnology:EntityBase
    {
        public string? Name { get; set; }
    }

    public class VigusGPUContext:DbContext
    {
        public VigusGPUContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Gpu> Gpus { get; set; }
        public DbSet<GpuSeries> GpuSeries { get; set; }
        public DbSet<GpuModel> GpuModels { get; set; }
        public DbSet<GpuTechnology> GpuTechnologies { get; set; }
    }
}
