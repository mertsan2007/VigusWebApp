using Microsoft.EntityFrameworkCore;

namespace Vigus.Web.Data;

public class VigusGpuContext : DbContext
{
    public VigusGpuContext(DbContextOptions options) : base(options) { }

    public DbSet<Gpu> Gpus { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<GpuModel> GpuModels { get; set; }
    public DbSet<GpuTechnology> GpuTechnologies { get; set; }
    public DbSet<DriverVersion> DriverVersions { get; set; }
    public DbSet<OsVersion> OsVersions { get; set; }
    public DbSet<GpuImage> GpuImages { get; set; }

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

        modelBuilder.Entity<Series>().HasData(
            new Series { Id = 1, Name = "C Series" },
            new Series { Id = 2, Name = "B Series" },
            new Series { Id = 3, Name = "A Series" }
            );

        modelBuilder.Entity<GpuModel>().HasData(
            new GpuModel { Id = 1, SeriesId = 2, Name = "B 500 Series"},
            new GpuModel { Id = 2, SeriesId = 2, Name = "B 570 Series" },
            new GpuModel { Id = 3, SeriesId = 2, Name = "B 60 Series" },
            new GpuModel { Id = 4, SeriesId = 1, Name = "C 90 Series" },
            new GpuModel { Id = 5, SeriesId = 1, Name = "C 80 Series" },
            new GpuModel { Id = 6, SeriesId = 1, Name = "C 900 Series" },
            new GpuModel { Id = 7, SeriesId = 3, Name = "A 100 Series" },
            new GpuModel { Id = 8, SeriesId = 3, Name = "A 11 Series" }
            );
        
        modelBuilder.Entity<DriverVersion>().HasData(
            new DriverVersion{Id = 1, Name = "Vigus Driver Software v1.0.2", Description = "First release for legacy GPUs"}
            );

        modelBuilder.Entity<GpuTechnology>().HasData(
            new GpuTechnology{Id = 1, Name = "d3d12 optimisations", Description = "asdgfsdgaasgsdgasdga"}
            );
    }
    
}