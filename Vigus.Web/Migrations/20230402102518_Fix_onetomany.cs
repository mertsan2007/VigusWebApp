using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class Fix_onetomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GpuImages_Gpus_GpuId",
                table: "GpuImages");

            migrationBuilder.DropIndex(
                name: "IX_GpuImages_GpuId",
                table: "GpuImages");

            migrationBuilder.DropColumn(
                name: "GpuId",
                table: "GpuImages");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Gpus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_ImageId",
                table: "Gpus",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gpus_GpuImages_ImageId",
                table: "Gpus",
                column: "ImageId",
                principalTable: "GpuImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gpus_GpuImages_ImageId",
                table: "Gpus");

            migrationBuilder.DropIndex(
                name: "IX_Gpus_ImageId",
                table: "Gpus");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Gpus");

            migrationBuilder.AddColumn<int>(
                name: "GpuId",
                table: "GpuImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GpuImages_GpuId",
                table: "GpuImages",
                column: "GpuId");

            migrationBuilder.AddForeignKey(
                name: "FK_GpuImages_Gpus_GpuId",
                table: "GpuImages",
                column: "GpuId",
                principalTable: "Gpus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
