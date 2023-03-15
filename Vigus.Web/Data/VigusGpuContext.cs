using Microsoft.EntityFrameworkCore;

namespace Vigus.Web.Data;

public class VigusGpuContext : DbContext
{
    private string _defTxt = "Vigus Driver Software ";

    public VigusGpuContext(DbContextOptions options) : base(options){ }

    public DbSet<Gpu> Gpus { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<GpuModel> GpuModels { get; set; }
    public DbSet<GpuTechnology> GpuTechnologies { get; set; }
    public DbSet<DriverVersion> DriverVersions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Gpu>().Property(col => col.ReleaseDate)
            .HasDefaultValueSql("getdate()");
        
        modelBuilder.Entity<Gpu>().HasIndex(col => col.Name)
            .IsUnique();
                
        modelBuilder.Entity<Series>().HasIndex(col => col.Name)
            .IsUnique();
        
        modelBuilder.Entity<GpuModel>().HasIndex(col => col.Name)
            .IsUnique();
        
        modelBuilder.Entity<GpuTechnology>().HasIndex(col => col.Name)
            .IsUnique();
        
        modelBuilder.Entity<DriverVersion>().HasIndex(col => col.Name)
            .IsUnique();
        
        modelBuilder.Entity<DriverVersion>().HasData(
            new List<DriverVersion>{
        new DriverVersion{ Id = 1, Name = _defTxt+"1.00" },
        new DriverVersion{ Id = 2, Name = _defTxt+"1.03" },
        new DriverVersion{ Id = 3, Name = _defTxt+"1.12" }
        }
        );
        
        modelBuilder.Entity<GpuTechnology>().HasData(
            new GpuTechnology { Id = 1, Name = "dummy" }
        );
        
        modelBuilder.Entity<Series>().HasData(
            new Series { Id = 1, Name = "C Series" },
            new Series { Id = 2, Name = "B Series" },
            new Series { Id = 3, Name = "A Series" }
            );
        
        modelBuilder.Entity<GpuModel>().HasData(
            new GpuModel { Id = 1, SeriesId = 2, Name = "B 500 Series" }
            );
        //modelBuilder.Entity<Gpu>().HasData(
        //    new Gpu
        //    {
        //        Name = "C98x",
        //        FullGpuName = "Vigus C98X",
        //        Cores = 455776,
        //        Tdp = 150,
        //        ReleaseDate = new DateTime(2023, 1, 14),
        //        Id = 1,
        //        Price = 300.00m,
        //        MemorySize = 12,
        //        ModelId = 0
        //    }
        //);

    }
}