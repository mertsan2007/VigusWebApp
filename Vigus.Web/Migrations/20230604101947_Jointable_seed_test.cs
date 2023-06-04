using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class Jointable_seed_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DriverVersionGpu",
                columns: new[] { "GpusId", "SupportedDriverVersionsId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DriverVersionGpu",
                keyColumns: new[] { "GpusId", "SupportedDriverVersionsId" },
                keyValues: new object[] { 2, 3 });
        }
    }
}
