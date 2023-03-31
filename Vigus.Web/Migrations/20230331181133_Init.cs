using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KnownIssues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FixedChanges = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GpuImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpuImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GpuTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpuTechnologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OsVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OsVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverVersionOsVersion",
                columns: table => new
                {
                    DriverVersionsId = table.Column<int>(type: "int", nullable: false),
                    OsVersionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverVersionOsVersion", x => new { x.DriverVersionsId, x.OsVersionsId });
                    table.ForeignKey(
                        name: "FK_DriverVersionOsVersion_DriverVersions_DriverVersionsId",
                        column: x => x.DriverVersionsId,
                        principalTable: "DriverVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverVersionOsVersion_OsVersions_OsVersionsId",
                        column: x => x.OsVersionsId,
                        principalTable: "OsVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GpuModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SeriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpuModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GpuModels_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GpuModelGpuTechnology",
                columns: table => new
                {
                    GpuModelsId = table.Column<int>(type: "int", nullable: false),
                    GpuTechnologiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpuModelGpuTechnology", x => new { x.GpuModelsId, x.GpuTechnologiesId });
                    table.ForeignKey(
                        name: "FK_GpuModelGpuTechnology_GpuModels_GpuModelsId",
                        column: x => x.GpuModelsId,
                        principalTable: "GpuModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GpuModelGpuTechnology_GpuTechnologies_GpuTechnologiesId",
                        column: x => x.GpuTechnologiesId,
                        principalTable: "GpuTechnologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gpus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    Tdp = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MemorySize = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gpus_GpuImages_ImageId",
                        column: x => x.ImageId,
                        principalTable: "GpuImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gpus_GpuModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "GpuModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverVersionGpu",
                columns: table => new
                {
                    GpusId = table.Column<int>(type: "int", nullable: false),
                    SupportedDriverVersionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverVersionGpu", x => new { x.GpusId, x.SupportedDriverVersionsId });
                    table.ForeignKey(
                        name: "FK_DriverVersionGpu_DriverVersions_SupportedDriverVersionsId",
                        column: x => x.SupportedDriverVersionsId,
                        principalTable: "DriverVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverVersionGpu_Gpus_GpusId",
                        column: x => x.GpusId,
                        principalTable: "Gpus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GpuTechnologies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "asdgfsdgaasgsdgasdga", "d3d12 optimisations" });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C Series" },
                    { 2, "B Series" },
                    { 3, "A Series" }
                });

            migrationBuilder.InsertData(
                table: "GpuModels",
                columns: new[] { "Id", "Name", "SeriesId" },
                values: new object[] { 1, "B 500 Series", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_DriverVersionGpu_SupportedDriverVersionsId",
                table: "DriverVersionGpu",
                column: "SupportedDriverVersionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverVersionOsVersion_OsVersionsId",
                table: "DriverVersionOsVersion",
                column: "OsVersionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverVersions_Name",
                table: "DriverVersions",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GpuModelGpuTechnology_GpuTechnologiesId",
                table: "GpuModelGpuTechnology",
                column: "GpuTechnologiesId");

            migrationBuilder.CreateIndex(
                name: "IX_GpuModels_Name",
                table: "GpuModels",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GpuModels_SeriesId",
                table: "GpuModels",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_ImageId",
                table: "Gpus",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_ModelId",
                table: "Gpus",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_Name",
                table: "Gpus",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GpuTechnologies_Name",
                table: "GpuTechnologies",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Series_Name",
                table: "Series",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverVersionGpu");

            migrationBuilder.DropTable(
                name: "DriverVersionOsVersion");

            migrationBuilder.DropTable(
                name: "GpuModelGpuTechnology");

            migrationBuilder.DropTable(
                name: "Gpus");

            migrationBuilder.DropTable(
                name: "DriverVersions");

            migrationBuilder.DropTable(
                name: "OsVersions");

            migrationBuilder.DropTable(
                name: "GpuTechnologies");

            migrationBuilder.DropTable(
                name: "GpuImages");

            migrationBuilder.DropTable(
                name: "GpuModels");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
