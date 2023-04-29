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
    public DbSet<Image> Images { get; set; }

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

        modelBuilder.Entity<Image>().HasIndex(col => col.Name)
            .IsUnique();

        //modelBuilder.Entity<GpuModel>().HasMany(x => x.GpuTechnologies).WithMany(x => //x.GpuModels)
        //    .UsingEntity(h => h
        //        .ToTable("ModelTechnology")
        //        .HasData()
        //    );

        modelBuilder.Entity<Series>().HasData(
            new Series { Id = 1, Name = "C Series" },
            new Series { Id = 2, Name = "B Series" },
            new Series { Id = 3, Name = "A Series" }
            );

        modelBuilder.Entity<GpuModel>().HasData(
            new GpuModel { Id = 1, SeriesId = 2, Name = "B 500 Series" },
            new GpuModel { Id = 2, SeriesId = 2, Name = "B 570 Series" },
            new GpuModel { Id = 3, SeriesId = 2, Name = "B 60 Series" },
            new GpuModel { Id = 4, SeriesId = 1, Name = "C 90 Series" },
            new GpuModel { Id = 5, SeriesId = 1, Name = "C 80 Series" },
            new GpuModel { Id = 6, SeriesId = 1, Name = "C 900 Series" },
            new GpuModel { Id = 7, SeriesId = 3, Name = "A 100 Series" }
            );

        modelBuilder.Entity<DriverVersion>().HasData(
            new() { Id = 1, Name = "v1.0.2", Description = "First release for legacy GPUs" },
            new() { Id = 2, Name = "v1.1.0", Description = "Added support for more variety of GPUs", KnownIssues = "Random crash may occur", FixedChanges = "Low performance fixed" }
            );

        modelBuilder.Entity<Image>().HasData(
            new() { Id = 1, Name = "defaultgpu.png", Title = "Default GpuImage" },
            new() { Id = 2, Name = "defaulttechnology.png", Title = "Default TechnologyImage" }
            );

        modelBuilder.Entity<OsVersion>().HasData(
            new() { Id = 1, Name = "Windows 7" },
            new() { Id = 2, Name = "Windows 8" },
            new() { Id = 3, Name = "Windows 10" },
            new() { Id = 4, Name = "Windows 11" },
            new() { Id = 5, Name = "Ubuntu" },
            new() { Id = 6, Name = "Linux Mint" }
            );

        modelBuilder.Entity<GpuTechnology>().HasData(
            new DriverVersion { Id = 2, Name = "D3d Optimizations", Description = "DirectX Optimisations for Vigus Graphics" },
            new DriverVersion { Id = 3, Name = "VigusBoost", Description = "Boost performance with minimal resolution change" }
            );

        modelBuilder.Entity<Gpu>().HasData(
            new Gpu
            {
                Id = 1,
                Name = "C98X",
                ModelId = 4,
                Description = "High-end GPU that is ready to game and compute. Built by Vigus.",
                Cores = 6000,
                ImageId = 1,
                MemorySize = 18,
                Price = 899.99m,
                Tdp = 300
            }
            );
    }
}