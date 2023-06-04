using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class Full_seed_jointable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "DriverVersionGpu",
                columns: new[] { "GpusId", "SupportedDriverVersionsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 3, 1 },
                    { 3, 3 },
                    { 4, 2 },
                    { 5, 3 }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "DriverVersionOsVersion",
                keyColumns: new[] { "DriverVersionsId", "OsVersionsId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "GpuModelGpuTechnology",
                keyColumns: new[] { "GpuModelsId", "GpuTechnologiesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GpuModelGpuTechnology",
                keyColumns: new[] { "GpuModelsId", "GpuTechnologiesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GpuModelGpuTechnology",
                keyColumns: new[] { "GpuModelsId", "GpuTechnologiesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GpuModelGpuTechnology",
                keyColumns: new[] { "GpuModelsId", "GpuTechnologiesId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "GpuModelGpuTechnology",
                keyColumns: new[] { "GpuModelsId", "GpuTechnologiesId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GpuModelGpuTechnology",
                keyColumns: new[] { "GpuModelsId", "GpuTechnologiesId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GpuModelGpuTechnology",
                keyColumns: new[] { "GpuModelsId", "GpuTechnologiesId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "GpuModelGpuTechnology",
                keyColumns: new[] { "GpuModelsId", "GpuTechnologiesId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "GpuModelGpuTechnology",
                keyColumns: new[] { "GpuModelsId", "GpuTechnologiesId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "DriverVersionGpu",
                columns: new[] { "GpusId", "SupportedDriverVersionsId" },
                values: new object[] { 2, 3 });
        }
    }
}
