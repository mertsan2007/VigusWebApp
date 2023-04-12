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
    [Migration("20230412173323_ImagesFix")]
    partial class ImagesFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
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

                    b.ToTable("DriverVersionGpu");
                });

            modelBuilder.Entity("DriverVersionOsVersion", b =>
                {
                    b.Property<int>("DriverVersionsId")
                        .HasColumnType("int");

                    b.Property<int>("OsVersionsId")
                        .HasColumnType("int");

                    b.HasKey("DriverVersionsId", "OsVersionsId");

                    b.HasIndex("OsVersionsId");

                    b.ToTable("DriverVersionOsVersion");
                });

            modelBuilder.Entity("GpuModelGpuTechnology", b =>
                {
                    b.Property<int>("GpuModelsId")
                        .HasColumnType("int");

                    b.Property<int>("GpuTechnologiesId")
                        .HasColumnType("int");

                    b.HasKey("GpuModelsId", "GpuTechnologiesId");

                    b.HasIndex("GpuTechnologiesId");

                    b.ToTable("GpuModelGpuTechnology");
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
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("DriverVersions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "First release for legacy GPUs",
                            Name = "v1.0.2"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Added support for more variety of GPUs",
                            FixedChanges = "Low performance fixed",
                            KnownIssues = "Random crash may occur",
                            Name = "v1.1.0"
                        });
                });

            modelBuilder.Entity("Vigus.Web.Data.Gpu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cores")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("MemorySize")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ReleaseDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Tdp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("ModelId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Gpus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cores = 6000,
                            Description = "High-end GPU that is ready to game and compute. Built by Vigus.",
                            ImageId = 1,
                            MemorySize = 18,
                            ModelId = 4,
                            Name = "C98X",
                            Price = 899.99m,
                            Tdp = 300
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
                            Name = "B 500 Series",
                            SeriesId = 2
                        },
                        new
                        {
                            Id = 2,
                            Name = "B 570 Series",
                            SeriesId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "B 60 Series",
                            SeriesId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "C 90 Series",
                            SeriesId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "C 80 Series",
                            SeriesId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "C 900 Series",
                            SeriesId = 1
                        },
                        new
                        {
                            Id = 7,
                            Name = "A 100 Series",
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
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("GpuTechnologies");
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
                            Name = "C Series"
                        },
                        new
                        {
                            Id = 2,
                            Name = "B Series"
                        },
                        new
                        {
                            Id = 3,
                            Name = "A Series"
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
