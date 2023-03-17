using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vigus.data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DriverVersions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "GpuTechnologies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "asdgfsdgaasgsdgasdga", "d3d12 optimisations" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DriverVersions");
        }
    }
}
