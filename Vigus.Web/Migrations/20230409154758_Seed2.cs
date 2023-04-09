using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class Seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gpus_GpuImages_ImageId",
                table: "Gpus");

            migrationBuilder.DropForeignKey(
                name: "FK_GpuTechnologies_GpuImages_ImageId",
                table: "GpuTechnologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GpuImages",
                table: "GpuImages");

            migrationBuilder.RenameTable(
                name: "GpuImages",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_GpuImages_Name",
                table: "Images",
                newName: "IX_Images_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gpus_Images_ImageId",
                table: "Gpus",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GpuTechnologies_Images_ImageId",
                table: "GpuTechnologies",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gpus_Images_ImageId",
                table: "Gpus");

            migrationBuilder.DropForeignKey(
                name: "FK_GpuTechnologies_Images_ImageId",
                table: "GpuTechnologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "GpuImages");

            migrationBuilder.RenameIndex(
                name: "IX_Images_Name",
                table: "GpuImages",
                newName: "IX_GpuImages_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GpuImages",
                table: "GpuImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gpus_GpuImages_ImageId",
                table: "Gpus",
                column: "ImageId",
                principalTable: "GpuImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GpuTechnologies_GpuImages_ImageId",
                table: "GpuTechnologies",
                column: "ImageId",
                principalTable: "GpuImages",
                principalColumn: "Id");
        }
    }
}
