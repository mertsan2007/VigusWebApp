using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vigus.data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedListToCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DriverVersions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vigus Driver Software 1.00" },
                    { 2, "Vigus Driver Software 1.03" },
                    { 3, "Vigus Driver Software 1.12" }
                });

            migrationBuilder.InsertData(
                table: "GpuTechnologies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, null, "dummy" });
        }
    }
}
