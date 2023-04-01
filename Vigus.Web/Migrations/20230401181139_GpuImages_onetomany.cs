using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class GpuImages_onetomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GpuImages_GpuId",
                table: "GpuImages");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Gpus");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GpuImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GpuImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GpuImages_GpuId",
                table: "GpuImages",
                column: "GpuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GpuImages_GpuId",
                table: "GpuImages");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Gpus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "GpuImages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GpuImages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_GpuImages_GpuId",
                table: "GpuImages",
                column: "GpuId",
                unique: true);
        }
    }
}
