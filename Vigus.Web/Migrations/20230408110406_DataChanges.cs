using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class DataChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "GpuDriver",
                newName: "DriverVersionGpu");

            migrationBuilder.RenameIndex(
                name: "IX_GpuDriver_SupportedDriverVersionsId",
                table: "DriverVersionGpu",
                newName: "IX_DriverVersionGpu_SupportedDriverVersionsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GpuImages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DriverVersionGpu",
                table: "DriverVersionGpu",
                columns: new[] { "GpusId", "SupportedDriverVersionsId" });

            migrationBuilder.InsertData(
                table: "GpuImages",
                columns: new[] { "Id", "Name", "Title" },
                values: new object[] { 1, "defaultgpu.png", "Default GpuImage" });

            migrationBuilder.CreateIndex(
                name: "IX_GpuImages_Name",
                table: "GpuImages",
                column: "Name",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DriverVersionGpu_DriverVersions_SupportedDriverVersionsId",
                table: "DriverVersionGpu");

            migrationBuilder.DropForeignKey(
                name: "FK_DriverVersionGpu_Gpus_GpusId",
                table: "DriverVersionGpu");

            migrationBuilder.DropIndex(
                name: "IX_GpuImages_Name",
                table: "GpuImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DriverVersionGpu",
                table: "DriverVersionGpu");

            migrationBuilder.DeleteData(
                table: "GpuImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "DriverVersionGpu",
                newName: "GpuDriver");

            migrationBuilder.RenameIndex(
                name: "IX_DriverVersionGpu_SupportedDriverVersionsId",
                table: "GpuDriver",
                newName: "IX_GpuDriver_SupportedDriverVersionsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GpuImages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GpuDriver",
                table: "GpuDriver",
                columns: new[] { "GpusId", "SupportedDriverVersionsId" });

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
    }
}
