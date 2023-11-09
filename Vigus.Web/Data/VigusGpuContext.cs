using Microsoft.EntityFrameworkCore;

namespace Vigus.Web.Data;

public class VigusGpuContext : DbContext
{
    public VigusGpuContext(DbContextOptions options) : base(options)
    {
    }

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


        #region seed

        modelBuilder.Entity<Gpu>()
            .HasMany(x => x.SupportedDriverVersions)
            .WithMany(x => x.Gpus)
            .UsingEntity(x => x
                .ToTable("DriverVersionGpu")
                .HasData(
                    new { GpusId = 1, SupportedDriverVersionsId = 1},
                    new { GpusId = 1, SupportedDriverVersionsId = 2 },
                    new { GpusId = 1, SupportedDriverVersionsId = 3 },
                    new { GpusId = 2, SupportedDriverVersionsId = 1 },
                    new { GpusId = 2, SupportedDriverVersionsId = 2 },
                    new { GpusId = 3, SupportedDriverVersionsId = 3 },
                    new { GpusId = 3, SupportedDriverVersionsId = 1 },
                    new { GpusId = 4, SupportedDriverVersionsId = 2 },
                    new { GpusId = 5, SupportedDriverVersionsId = 3 }
                )
            );

        modelBuilder.Entity<GpuModel>()
            .HasMany(x => x.GpuTechnologies)
            .WithMany(x => x.GpuModels)
            .UsingEntity(x => x
                .ToTable("GpuModelGpuTechnology")
                .HasData(
                    new { GpuModelsId = 1, GpuTechnologiesId = 2},
                    new { GpuModelsId = 1, GpuTechnologiesId = 3 },
                    new { GpuModelsId = 2, GpuTechnologiesId = 2 },
                    new { GpuModelsId = 2, GpuTechnologiesId = 3 },
                    new { GpuModelsId = 3, GpuTechnologiesId = 3 },
                    new { GpuModelsId = 4, GpuTechnologiesId = 3 },
                    new { GpuModelsId = 5, GpuTechnologiesId = 2 },
                    new { GpuModelsId = 6, GpuTechnologiesId = 3 },
                    new { GpuModelsId = 7, GpuTechnologiesId = 2 }
                )
            );

        modelBuilder.Entity<DriverVersion>()
            .HasMany(x => x.OsVersions)
            .WithMany(x => x.DriverVersions)
            .UsingEntity(x => x
                .ToTable("DriverVersionOsVersion")
                .HasData(
                    new { DriverVersionsId = 1, OsVersionsId = 1},
                    new { DriverVersionsId = 1, OsVersionsId = 2 },
                    new { DriverVersionsId = 1, OsVersionsId = 3 },
                    new { DriverVersionsId = 1, OsVersionsId = 5 },
                    new { DriverVersionsId = 2, OsVersionsId = 2 },
                    new { DriverVersionsId = 2, OsVersionsId = 3 },
                    new { DriverVersionsId = 2, OsVersionsId = 5 },
                    new { DriverVersionsId = 2, OsVersionsId = 6 },
                    new { DriverVersionsId = 3, OsVersionsId = 3 },
                    new { DriverVersionsId = 3, OsVersionsId = 4 },
                    new { DriverVersionsId = 3, OsVersionsId = 5 },
                    new { DriverVersionsId = 3, OsVersionsId = 6 }
                    )
            );

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
            new DriverVersion { Id = 1, Name = "v1.0.2", Description = "initial release" },
            new DriverVersion
            {
                Id = 2, Name = "v1.1.0", Description = "second release",
                KnownIssues = "bugs are expected"
            },
            new DriverVersion { Id = 3, Name = "v1.1.1",Description="third release", FixedChanges = "bug fixes"}
        );

        modelBuilder.Entity<Image>().HasData(
            new Image { Id = 1, Name = "defaultgpu.png", Title = "Default GpuImage" },
            new Image { Id = 2, Name = "defaultimage128x128.png", Title = "defaultimage 128x128" },
            new Image { Id = 3, Name = "defaultimage496x250.png", Title = "defaultimage 496x250" }
        );

        modelBuilder.Entity<OsVersion>().HasData(
            new OsVersion { Id = 1, Name = "Windows 7" },
            new OsVersion { Id = 2, Name = "Windows 8" },
            new OsVersion { Id = 3, Name = "Windows 10" },
            new OsVersion { Id = 4, Name = "Windows 11" },
            new OsVersion { Id = 5, Name = "Ubuntu" },
            new OsVersion { Id = 6, Name = "Linux Mint" }
        );

        modelBuilder.Entity<GpuTechnology>().HasData(
            new GpuTechnology
            {
                Id = 2, Name = "technology1", Description = "desc",
                ImageId = 3
            },
            new GpuTechnology
            {
                Id = 3, Name = "technology2", Description = "desc",
                ImageId = 3
            }
        );

        modelBuilder.Entity<Gpu>().HasData(
            new Gpu
            {
                Id = 1,
                Name = "Vigus C900",
                ModelId = 6,
                Description = "first gpu from vigus",
                Cores = 4750,
                ImageId = 1,
                MemorySize = 12,
                Price = 899.99m,
                Tdp = 350,
                ReleaseDate = new DateTime(2021,5,15)
            },
            new Gpu
            {
                Id = 2,
                Name = "Vigus C98X",
                ModelId = 4,
                Description = "gpu",
                Cores = 6000,
                ImageId = 1,
                MemorySize = 18,
                Price = 899.99m,
                Tdp = 300
            },
            new Gpu
            {
                Id = 3,
                Name = "Vigus C98X 20GB",
                ModelId = 4,
                Cores = 6200,
                ImageId = 1,
                MemorySize = 20,
                Price = 949.99m,
                Tdp = 300
            },
            new Gpu
            {
                Id = 4,
                Name = "Vigus C98",
                ModelId = 4,
                Cores = 5500,
                ImageId = 1,
                MemorySize = 16,
                Price = 749.99m,
                Tdp = 250
            },
            new Gpu
            {
                Id = 5,
                Name = "Vigus C87X",
                ModelId = 5,
                Cores = 4800,
                ImageId = 1,
                MemorySize = 16,
                Price = 699.99m,
                Tdp = 225
            },
            new Gpu
            {
                Id = 6,
                Name = "Vigus C85",
                ModelId = 5,
                Cores = 4000,
                ImageId = 1,
                MemorySize = 12,
                Price = 599.99m,
                Tdp = 180
            },
            new Gpu
            {
                Id = 7,
                Name = "Vigus B573",
                ModelId = 2,
                Cores = 2100,
                ImageId = 1,
                MemorySize = 8,
                Price = 299.99m,
                Tdp = 100
            },
            new Gpu
            {
                Id = 8,
                Name = "Vigus B67",
                ModelId = 3,
                Cores = 3000,
                ImageId = 1,
                MemorySize = 10,
                Price = 319.99m,
                Tdp = 100
            },
            new Gpu
            {
                Id = 9,
                Name = "Vigus A100",
                Description = "lower power consumption",
                ModelId = 7,
                Cores = 1200,
                ImageId = 1,
                MemorySize = 4,
                Price = 149.99m,
                Tdp = 75
            }
        );

        #endregion
    }
}