using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KnownIssues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FixedChanges = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OsVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "GpuTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpuTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GpuTechnologies_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cores = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Gpus_GpuModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "GpuModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gpus_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
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
                table: "DriverVersions",
                columns: new[] { "Id", "Description", "FixedChanges", "KnownIssues", "Name" },
                values: new object[,]
                {
                    { 1, "initial release", null, null, "v1.0.2" },
                    { 2, "second release", null, "bugs are expected", "v1.1.0" },
                    { 3, "third release", "bug fixes", null, "v1.1.1" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "Title" },
                values: new object[,]
                {
                    { 1, "defaultgpu.png", "Default GpuImage" },
                    { 2, "defaultimage128x128.png", "defaultimage 128x128" },
                    { 3, "defaultimage496x250.png", "defaultimage 496x250" }
                });

            migrationBuilder.InsertData(
                table: "OsVersions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Windows 7" },
                    { 2, "Windows 8" },
                    { 3, "Windows 10" },
                    { 4, "Windows 11" },
                    { 5, "Ubuntu" },
                    { 6, "Linux Mint" }
                });

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
                table: "DriverVersionOsVersion",
                columns: new[] { "DriverVersionsId", "OsVersionsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 5 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "GpuModels",
                columns: new[] { "Id", "Name", "SeriesId" },
                values: new object[,]
                {
                    { 1, "B 500 Series", 2 },
                    { 2, "B 570 Series", 2 },
                    { 3, "B 60 Series", 2 },
                    { 4, "C 90 Series", 1 },
                    { 5, "C 80 Series", 1 },
                    { 6, "C 900 Series", 1 },
                    { 7, "A 100 Series", 3 }
                });

            migrationBuilder.InsertData(
                table: "GpuTechnologies",
                columns: new[] { "Id", "Description", "ImageId", "Name" },
                values: new object[,]
                {
                    { 2, "desc", 3, "technology1" },
                    { 3, "desc", 3, "technology2" }
                });

            migrationBuilder.InsertData(
                table: "GpuModelGpuTechnology",
                columns: new[] { "GpuModelsId", "GpuTechnologiesId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 2 },
                    { 6, 3 },
                    { 7, 2 }
                });

            migrationBuilder.InsertData(
                table: "Gpus",
                columns: new[] { "Id", "Cores", "Description", "ImageId", "MemorySize", "ModelId", "Name", "Price", "ReleaseDate", "Tdp" },
                values: new object[] { 1, 4750, "first gpu from vigus", 1, 12, 6, "Vigus C900", 899.99m, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 350 });

            migrationBuilder.InsertData(
                table: "Gpus",
                columns: new[] { "Id", "Cores", "Description", "ImageId", "MemorySize", "ModelId", "Name", "Price", "Tdp" },
                values: new object[,]
                {
                    { 2, 6000, "gpu", 1, 18, 4, "Vigus C98X", 899.99m, 300 },
                    { 3, 6200, null, 1, 20, 4, "Vigus C98X 20GB", 949.99m, 300 },
                    { 4, 5500, null, 1, 16, 4, "Vigus C98", 749.99m, 250 },
                    { 5, 4800, null, 1, 16, 5, "Vigus C87X", 699.99m, 225 },
                    { 6, 4000, null, 1, 12, 5, "Vigus C85", 599.99m, 180 },
                    { 7, 2100, null, 1, 8, 2, "Vigus B573", 299.99m, 100 },
                    { 8, 3000, null, 1, 10, 3, "Vigus B67", 319.99m, 100 },
                    { 9, 1200, "lower power consumption", 1, 4, 7, "Vigus A100", 149.99m, 75 }
                });

            migrationBuilder.InsertData(
                table: "DriverVersionGpu",
                columns: new[] { "GpusId", "SupportedDriverVersionsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 3 },
                    { 4, 2 },
                    { 5, 3 }
                });

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
                unique: true);

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
                name: "IX_GpuTechnologies_ImageId",
                table: "GpuTechnologies",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_GpuTechnologies_Name",
                table: "GpuTechnologies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_Name",
                table: "Images",
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
                name: "GpuModels");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
