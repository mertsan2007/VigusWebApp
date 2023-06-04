﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vigus.Web.Data;

#nullable disable

namespace Vigus.Web.Migrations
{
    [DbContext(typeof(VigusGpuContext))]
    [Migration("20230604105114_Full_seed_jointable")]
    partial class Full_seed_jointable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DriverVersionGpu", b =>
                {
                    b.Property<int>("GpusId")
                        .HasColumnType("int");

                    b.Property<int>("SupportedDriverVersionsId")
                        .HasColumnType("int");

                    b.HasKey("GpusId", "SupportedDriverVersionsId");

                    b.HasIndex("SupportedDriverVersionsId");

                    b.ToTable("DriverVersionGpu", (string)null);

                    b.HasData(
                        new
                        {
                            GpusId = 1,
                            SupportedDriverVersionsId = 1
                        },
                        new
                        {
                            GpusId = 1,
                            SupportedDriverVersionsId = 2
                        },
                        new
                        {
                            GpusId = 1,
                            SupportedDriverVersionsId = 3
                        },
                        new
                        {
                            GpusId = 2,
                            SupportedDriverVersionsId = 1
                        },
                        new
                        {
                            GpusId = 2,
                            SupportedDriverVersionsId = 2
                        },
                        new
                        {
                            GpusId = 3,
                            SupportedDriverVersionsId = 3
                        },
                        new
                        {
                            GpusId = 3,
                            SupportedDriverVersionsId = 1
                        },
                        new
                        {
                            GpusId = 4,
                            SupportedDriverVersionsId = 2
                        },
                        new
                        {
                            GpusId = 5,
                            SupportedDriverVersionsId = 3
                        });
                });

            modelBuilder.Entity("DriverVersionOsVersion", b =>
                {
                    b.Property<int>("DriverVersionsId")
                        .HasColumnType("int");

                    b.Property<int>("OsVersionsId")
                        .HasColumnType("int");

                    b.HasKey("DriverVersionsId", "OsVersionsId");

                    b.HasIndex("OsVersionsId");

                    b.ToTable("DriverVersionOsVersion", (string)null);

                    b.HasData(
                        new
                        {
                            DriverVersionsId = 1,
                            OsVersionsId = 1
                        },
                        new
                        {
                            DriverVersionsId = 1,
                            OsVersionsId = 2
                        },
                        new
                        {
                            DriverVersionsId = 1,
                            OsVersionsId = 3
                        },
                        new
                        {
                            DriverVersionsId = 1,
                            OsVersionsId = 5
                        },
                        new
                        {
                            DriverVersionsId = 2,
                            OsVersionsId = 2
                        },
                        new
                        {
                            DriverVersionsId = 2,
                            OsVersionsId = 3
                        },
                        new
                        {
                            DriverVersionsId = 2,
                            OsVersionsId = 5
                        },
                        new
                        {
                            DriverVersionsId = 2,
                            OsVersionsId = 6
                        },
                        new
                        {
                            DriverVersionsId = 3,
                            OsVersionsId = 3
                        },
                        new
                        {
                            DriverVersionsId = 3,
                            OsVersionsId = 4
                        },
                        new
                        {
                            DriverVersionsId = 3,
                            OsVersionsId = 5
                        },
                        new
                        {
                            DriverVersionsId = 3,
                            OsVersionsId = 6
                        });
                });

            modelBuilder.Entity("GpuModelGpuTechnology", b =>
                {
                    b.Property<int>("GpuModelsId")
                        .HasColumnType("int");

                    b.Property<int>("GpuTechnologiesId")
                        .HasColumnType("int");

                    b.HasKey("GpuModelsId", "GpuTechnologiesId");

                    b.HasIndex("GpuTechnologiesId");

                    b.ToTable("GpuModelGpuTechnology", (string)null);

                    b.HasData(
                        new
                        {
                            GpuModelsId = 1,
                            GpuTechnologiesId = 2
                        },
                        new
                        {
                            GpuModelsId = 1,
                            GpuTechnologiesId = 3
                        },
                        new
                        {
                            GpuModelsId = 2,
                            GpuTechnologiesId = 2
                        },
                        new
                        {
                            GpuModelsId = 2,
                            GpuTechnologiesId = 3
                        },
                        new
                        {
                            GpuModelsId = 3,
                            GpuTechnologiesId = 3
                        },
                        new
                        {
                            GpuModelsId = 4,
                            GpuTechnologiesId = 3
                        },
                        new
                        {
                            GpuModelsId = 5,
                            GpuTechnologiesId = 2
                        },
                        new
                        {
                            GpuModelsId = 6,
                            GpuTechnologiesId = 3
                        },
                        new
                        {
                            GpuModelsId = 7,
                            GpuTechnologiesId = 2
                        });
                });

            modelBuilder.Entity("Vigus.Web.Data.DriverVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FixedChanges")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KnownIssues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DriverVersions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "ilk sürüm",
                            Name = "v1.0.2"
                        },
                        new
                        {
                            Id = 2,
                            Description = "ikinci sürüm",
                            FixedChanges = "hata düzeltmesi",
                            KnownIssues = "aaaa",
                            Name = "v1.1.0"
                        },
                        new
                        {
                            Id = 3,
                            FixedChanges = "hata düzeltmeleri",
                            Name = "v1.1.1"
                        });
                });

            modelBuilder.Entity("Vigus.Web.Data.Gpu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Cores")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("MemorySize")
                        .HasColumnType("int");

                    b.Property<int?>("ModelId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ReleaseDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("Tdp")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("ModelId");

                    b.ToTable("Gpus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cores = 4750,
                            Description = "ilk gpu",
                            ImageId = 1,
                            MemorySize = 12,
                            ModelId = 6,
                            Name = "Vigus C900",
                            Price = 899.99m,
                            ReleaseDate = new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tdp = 350
                        },
                        new
                        {
                            Id = 2,
                            Cores = 6000,
                            Description = "gpu",
                            ImageId = 1,
                            MemorySize = 18,
                            ModelId = 4,
                            Name = "Vigus C98X",
                            Price = 899.99m,
                            Tdp = 300
                        },
                        new
                        {
                            Id = 3,
                            Cores = 6200,
                            ImageId = 1,
                            MemorySize = 20,
                            ModelId = 4,
                            Name = "Vigus C98X 20GB",
                            Price = 949.99m,
                            Tdp = 300
                        },
                        new
                        {
                            Id = 4,
                            Cores = 5500,
                            ImageId = 1,
                            MemorySize = 16,
                            ModelId = 4,
                            Name = "Vigus C98",
                            Price = 749.99m,
                            Tdp = 250
                        },
                        new
                        {
                            Id = 5,
                            Cores = 4800,
                            ImageId = 1,
                            MemorySize = 16,
                            ModelId = 5,
                            Name = "Vigus C87X",
                            Price = 699.99m,
                            Tdp = 225
                        },
                        new
                        {
                            Id = 6,
                            Cores = 4000,
                            ImageId = 1,
                            MemorySize = 12,
                            ModelId = 5,
                            Name = "Vigus C85",
                            Price = 599.99m,
                            Tdp = 180
                        },
                        new
                        {
                            Id = 7,
                            Cores = 2100,
                            ImageId = 1,
                            MemorySize = 8,
                            ModelId = 2,
                            Name = "Vigus B573",
                            Price = 299.99m,
                            Tdp = 100
                        },
                        new
                        {
                            Id = 8,
                            Cores = 3000,
                            ImageId = 1,
                            MemorySize = 10,
                            ModelId = 3,
                            Name = "Vigus B67",
                            Price = 319.99m,
                            Tdp = 100
                        },
                        new
                        {
                            Id = 9,
                            Cores = 1200,
                            Description = "düşük güç tüketimi",
                            ImageId = 1,
                            MemorySize = 4,
                            ModelId = 7,
                            Name = "Vigus A100",
                            Price = 149.99m,
                            Tdp = 75
                        });
                });

            modelBuilder.Entity("Vigus.Web.Data.GpuModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SeriesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("SeriesId");

                    b.ToTable("GpuModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "B 500 Serisi",
                            SeriesId = 2
                        },
                        new
                        {
                            Id = 2,
                            Name = "B 570 Serisi",
                            SeriesId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "B 60 Serisi",
                            SeriesId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "C 90 Serisi",
                            SeriesId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "C 80 Serisi",
                            SeriesId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "C 900 Serisi",
                            SeriesId = 1
                        },
                        new
                        {
                            Id = 7,
                            Name = "A 100 Serisi",
                            SeriesId = 3
                        });
                });

            modelBuilder.Entity("Vigus.Web.Data.GpuTechnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("GpuTechnologies");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Description = "açıklama",
                            ImageId = 3,
                            Name = "teknoloji1"
                        },
                        new
                        {
                            Id = 3,
                            Description = "açıklama",
                            ImageId = 3,
                            Name = "teknoloji2"
                        });
                });

            modelBuilder.Entity("Vigus.Web.Data.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "defaultgpu.png",
                            Title = "Default GpuImage"
                        },
                        new
                        {
                            Id = 2,
                            Name = "defaultimage128x128.png",
                            Title = "defaultimage 128x128"
                        },
                        new
                        {
                            Id = 3,
                            Name = "defaultimage496x250.png",
                            Title = "defaultimage 496x250"
                        });
                });

            modelBuilder.Entity("Vigus.Web.Data.OsVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OsVersions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Windows 7"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Windows 8"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Windows 10"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Windows 11"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ubuntu"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Linux Mint"
                        });
                });

            modelBuilder.Entity("Vigus.Web.Data.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Series");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C Serisi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "B Serisi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "A Serisi"
                        });
                });

            modelBuilder.Entity("DriverVersionGpu", b =>
                {
                    b.HasOne("Vigus.Web.Data.Gpu", null)
                        .WithMany()
                        .HasForeignKey("GpusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vigus.Web.Data.DriverVersion", null)
                        .WithMany()
                        .HasForeignKey("SupportedDriverVersionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DriverVersionOsVersion", b =>
                {
                    b.HasOne("Vigus.Web.Data.DriverVersion", null)
                        .WithMany()
                        .HasForeignKey("DriverVersionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vigus.Web.Data.OsVersion", null)
                        .WithMany()
                        .HasForeignKey("OsVersionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GpuModelGpuTechnology", b =>
                {
                    b.HasOne("Vigus.Web.Data.GpuModel", null)
                        .WithMany()
                        .HasForeignKey("GpuModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vigus.Web.Data.GpuTechnology", null)
                        .WithMany()
                        .HasForeignKey("GpuTechnologiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vigus.Web.Data.Gpu", b =>
                {
                    b.HasOne("Vigus.Web.Data.Image", "Image")
                        .WithMany("Gpus")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vigus.Web.Data.GpuModel", "Model")
                        .WithMany("Gpus")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Vigus.Web.Data.GpuModel", b =>
                {
                    b.HasOne("Vigus.Web.Data.Series", "Series")
                        .WithMany("GpuModels")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Series");
                });

            modelBuilder.Entity("Vigus.Web.Data.GpuTechnology", b =>
                {
                    b.HasOne("Vigus.Web.Data.Image", "Image")
                        .WithMany("Technologies")
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Vigus.Web.Data.GpuModel", b =>
                {
                    b.Navigation("Gpus");
                });

            modelBuilder.Entity("Vigus.Web.Data.Image", b =>
                {
                    b.Navigation("Gpus");

                    b.Navigation("Technologies");
                });

            modelBuilder.Entity("Vigus.Web.Data.Series", b =>
                {
                    b.Navigation("GpuModels");
                });
#pragma warning restore 612, 618
        }
    }
}
