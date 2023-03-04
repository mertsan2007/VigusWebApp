using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vigus.data.Data;

    #region Entities
    public class EntityBase
    {
        public int Id { get; set; }
    }
    public class Gpu:EntityBase
    {
        public string? Name { get; set; }
        public string? FullGpuName { get; set; }
        public int? Cores { get; set; }
        public int Tdp { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal? Price { get; set; }
        public int MemorySize { get; set; }
        
        public int ModelId { get; set; }
        public virtual GpuModel? Model { get; set; }

        public virtual List<DriverVersion>? SupportedDriverVersions { get; set; }
    }
    public class Series:EntityBase
    {
        public string? Name { get; set; }

        public virtual List<GpuModel>? GpuModels { get; set; }
        //C, B, A
    }
    public class GpuModel : EntityBase
    {
        public string? Name { get; set; }

        public virtual List<Gpu>? Gpus { get; set; }

        public int SeriesId { get; set; }
        public virtual Series? Series{ get; set; }

        public virtual List<GpuTechnology>? GpuTechnologies { get; set; }
    //C 900 Series,C 800 Series
}
    public class GpuTechnology:EntityBase
    {
        public string? Name { get; set; }
        public virtual List<GpuModel>? GpuModels { get; set; }
        // hd decode-encode support, directx12 support
    }
    public class DriverVersion : EntityBase
    {
        public string? Name { get; set; }
        public virtual List<Gpu>? Gpus { get; set; }
        //vigus software 1.13, 1.14
    }
    #endregion

    public class VigusGPUContext:DbContext
    {
        public VigusGPUContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Gpu> Gpus { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<GpuModel> GpuModels { get; set; }
        public DbSet<GpuTechnology> GpuTechnologies { get; set; }
        public DbSet<DriverVersion> DriverVersions { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Gpu>().HasData(
        //        new Gpu
        //        {
        //            Name = "C98x", FullGpuName = "Vigus C98X", Cores = 455776, Tdp = 150,
        //            ReleaseDate = new DateTime(2023, 1, 14), Id = 1, Price = 300.00m, MemorySize = 12, ModelId = 0
        //        }
        //    );
        //}
    }