﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vigus.data.Data;

#nullable disable

namespace Vigus.data.Migrations
{
    [DbContext(typeof(VigusGpuContext))]
    partial class VigusGPUContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
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
                });

            modelBuilder.Entity("Vigus.data.Data.DriverVersion", b =>
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

                    b.ToTable("DriverVersions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Vigus Driver Software 1.00"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vigus Driver Software 1.03"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vigus Driver Software 1.12"
                        });
                });

            modelBuilder.Entity("Vigus.data.Data.Gpu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Cores")
                        .HasColumnType("int");

                    b.Property<string>("FullGpuName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MemorySize")
                        .HasColumnType("int");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Tdp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FullGpuName")
                        .IsUnique()
                        .HasFilter("[FullGpuName] IS NOT NULL");

                    b.HasIndex("ModelId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Gpus", (string)null);
                });

            modelBuilder.Entity("Vigus.data.Data.GpuModel", b =>
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

                    b.ToTable("GpuModels", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "B 500 Series",
                            SeriesId = 2
                        });
                });

            modelBuilder.Entity("Vigus.data.Data.GpuTechnology", b =>
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

                    b.ToTable("GpuTechnologies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "dummy"
                        });
                });

            modelBuilder.Entity("Vigus.data.Data.Series", b =>
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

                    b.ToTable("Series", (string)null);

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
                    b.HasOne("Vigus.data.Data.Gpu", null)
                        .WithMany()
                        .HasForeignKey("GpusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vigus.data.Data.DriverVersion", null)
                        .WithMany()
                        .HasForeignKey("SupportedDriverVersionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GpuModelGpuTechnology", b =>
                {
                    b.HasOne("Vigus.data.Data.GpuModel", null)
                        .WithMany()
                        .HasForeignKey("GpuModelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vigus.data.Data.GpuTechnology", null)
                        .WithMany()
                        .HasForeignKey("GpuTechnologiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vigus.data.Data.Gpu", b =>
                {
                    b.HasOne("Vigus.data.Data.GpuModel", "Model")
                        .WithMany("Gpus")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("Vigus.data.Data.GpuModel", b =>
                {
                    b.HasOne("Vigus.data.Data.Series", "Series")
                        .WithMany("GpuModels")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Series");
                });

            modelBuilder.Entity("Vigus.data.Data.GpuModel", b =>
                {
                    b.Navigation("Gpus");
                });

            modelBuilder.Entity("Vigus.data.Data.Series", b =>
                {
                    b.Navigation("GpuModels");
                });
#pragma warning restore 612, 618
        }
    }
}
