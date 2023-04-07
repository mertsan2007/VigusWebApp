using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class Manytomanyrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverVersionGpu_DriverVersions_SupportedDriverVersionsId",
                table: "DriverVersionGpu");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverVersionGpu_Gpus_GpusId",
                table: "DriverVersionGpu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverVersionGpu",
                table: "DriverVersionGpu");

            migrationBuilder.DeleteData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "DriverVersionGpu",
                newName: "GpuDriver");

            migrationBuilder.RenameIndex(
                name: "IX_DriverVersionGpu_SupportedDriverVersionsId",
                table: "GpuDriver",
                newName: "IX_GpuDriver_SupportedDriverVersionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GpuDriver",
                table: "GpuDriver",
                columns: new[] { "GpusId", "SupportedDriverVersionsId" });

            migrationBuilder.InsertData(
                table: "DriverVersions",
                columns: new[] { "Id", "Description", "FixedChanges", "KnownIssues", "Name" },
                values: new object[] { 1, "First release for legacy GPUs", null, null, "Vigus Driver Software v1.0.2" });

            migrationBuilder.InsertData(
                table: "GpuModels",
                columns: new[] { "Id", "Name", "SeriesId" },
                values: new object[,]
                {
                    { 2, "B 570 Series", 2 },
                    { 3, "B 60 Series", 2 },
                    { 4, "C 90 Series", 1 },
                    { 5, "C 80 Series", 1 },
                    { 6, "C 900 Series", 1 },
                    { 7, "A 100 Series", 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GpuDriver_DriverVersions_SupportedDriverVersionsId",
                table: "GpuDriver",
                column: "SupportedDriverVersionsId",
                principalTable: "DriverVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GpuDriver_Gpus_GpusId",
                table: "GpuDriver",
                column: "GpusId",
                principalTable: "Gpus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GpuDriver_DriverVersions_SupportedDriverVersionsId",
                table: "GpuDriver");

            migrationBuilder.DropForeignKey(
                name: "FK_GpuDriver_Gpus_GpusId",
                table: "GpuDriver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GpuDriver",
                table: "GpuDriver");

            migrationBuilder.DeleteData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.RenameTable(
                name: "GpuDriver",
                newName: "DriverVersionGpu");

            migrationBuilder.RenameIndex(
                name: "IX_GpuDriver_SupportedDriverVersionsId",
                table: "DriverVersionGpu",
                newName: "IX_DriverVersionGpu_SupportedDriverVersionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverVersionGpu",
                table: "DriverVersionGpu",
                columns: new[] { "GpusId", "SupportedDriverVersionsId" });

            migrationBuilder.InsertData(
                table: "GpuTechnologies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "asdgfsdgaasgsdgasdga", "d3d12 optimisations" });

            migrationBuilder.AddForeignKey(
                name: "FK_DriverVersionGpu_DriverVersions_SupportedDriverVersionsId",
                table: "DriverVersionGpu",
                column: "SupportedDriverVersionsId",
                principalTable: "DriverVersions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DriverVersionGpu_Gpus_GpusId",
                table: "DriverVersionGpu",
                column: "GpusId",
                principalTable: "Gpus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
