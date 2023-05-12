using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageId",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageId",
                value: null);
        }
    }
}
