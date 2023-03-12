using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vigus.data.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GpuTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpuTechnologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GpuModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullGpuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    Tdp = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MemorySize = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_DriverVersionGpu_SupportedDriverVersionsId",
                table: "DriverVersionGpu",
                column: "SupportedDriverVersionsId");

            migrationBuilder.CreateIndex(
                name: "IX_GpuModelGpuTechnology_GpuTechnologiesId",
                table: "GpuModelGpuTechnology",
                column: "GpuTechnologiesId");

            migrationBuilder.CreateIndex(
                name: "IX_GpuModels_SeriesId",
                table: "GpuModels",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_ModelId",
                table: "Gpus",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverVersionGpu");

            migrationBuilder.DropTable(
                name: "GpuModelGpuTechnology");

            migrationBuilder.DropTable(
                name: "DriverVersions");

            migrationBuilder.DropTable(
                name: "Gpus");

            migrationBuilder.DropTable(
                name: "GpuTechnologies");

            migrationBuilder.DropTable(
                name: "GpuModels");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
