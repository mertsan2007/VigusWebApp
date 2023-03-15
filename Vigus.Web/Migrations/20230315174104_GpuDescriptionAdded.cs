using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vigus.data.Migrations
{
    /// <inheritdoc />
    public partial class GpuDescriptionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gpus_FullGpuName",
                table: "Gpus");

            migrationBuilder.DropColumn(
                name: "FullGpuName",
                table: "Gpus");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GpuTechnologies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Gpus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "GpuTechnologies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Gpus");

            migrationBuilder.AddColumn<string>(
                name: "FullGpuName",
                table: "Gpus",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_FullGpuName",
                table: "Gpus",
                column: "FullGpuName",
                unique: true,
                filter: "[FullGpuName] IS NOT NULL");
        }
    }
}
