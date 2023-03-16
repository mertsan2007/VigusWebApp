using Microsoft.EntityFrameworkCore;

namespace Vigus.Web.Data;

public class VigusGpuContext : DbContext
{
    private string _defTxt = "Vigus Driver Software ";

    public VigusGpuContext(DbContextOptions options) : base(options) { }

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

        modelBuilder.Entity<Series>().HasData(
            new Series { Id = 1, Name = "C Series" },
            new Series { Id = 2, Name = "B Series" },
            new Series { Id = 3, Name = "A Series" }
            );

        modelBuilder.Entity<GpuModel>().HasData(
            new GpuModel { Id = 1, SeriesId = 2, Name = "B 500 Series" }
            );

    }
}