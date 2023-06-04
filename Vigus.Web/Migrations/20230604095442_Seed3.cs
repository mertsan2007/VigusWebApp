using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class Seed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Gpus_Name",
                table: "Gpus");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gpus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "ilk sürüm");

            migrationBuilder.UpdateData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "FixedChanges", "KnownIssues" },
                values: new object[] { "ikinci sürüm", "hata düzeltmesi", "aaaa" });

            migrationBuilder.InsertData(
                table: "DriverVersions",
                columns: new[] { "Id", "Description", "FixedChanges", "KnownIssues", "Name" },
                values: new object[] { 3, null, "hata düzeltmeleri", null, "v1.1.1" });

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "B 500 Serisi");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "B 570 Serisi");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "B 60 Serisi");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "C 90 Serisi");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "C 80 Serisi");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "C 900 Serisi");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "A 100 Serisi");

            migrationBuilder.UpdateData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "açıklama", "teknoloji1" });

            migrationBuilder.UpdateData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "açıklama", "teknoloji2" });

            migrationBuilder.UpdateData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cores", "Description", "MemorySize", "ModelId", "Name", "ReleaseDate", "Tdp" },
                values: new object[] { 4750, "ilk gpu", 12, 6, "Vigus C900", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 350 });

            migrationBuilder.InsertData(
                table: "Gpus",
                columns: new[] { "Id", "Cores", "Description", "ImageId", "MemorySize", "ModelId", "Name", "Price", "Tdp" },
                values: new object[,]
                {
                    { 2, 6000, "gpu", 1, 18, 4, "Vigus C98X", 899.99m, 300 },
                    { 3, 6200, null, 1, 20, 4, "Vigus C98X 20GB", 949.99m, 300 },
                    { 4, 5500, null, 1, 16, 4, "Vigus C98", 749.99m, 250 },
                    { 5, 4800, null, 1, 16, 5, "Vigus C87X", 699.99m, 225 },
                    { 6, 4000, null, 1, 12, 5, "Vigus C85", 599.99m, 180 },
                    { 7, 2100, null, 1, 8, 2, "Vigus B573", 299.99m, 100 },
                    { 8, 3000, null, 1, 10, 3, "Vigus B67", 319.99m, 100 },
                    { 9, 1200, "düşük güç tüketimi", 1, 4, 7, "Vigus A100", 149.99m, 75 }
                });

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "C Serisi");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "B Serisi");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "A Serisi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gpus",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "First release for legacy GPUs");

            migrationBuilder.UpdateData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "FixedChanges", "KnownIssues" },
                values: new object[] { "Added support for more variety of GPUs", "Low performance fixed", "Random crash may occur" });

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "B 500 Series");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "B 570 Series");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "B 60 Series");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "C 90 Series");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "C 80 Series");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "C 900 Series");

            migrationBuilder.UpdateData(
                table: "GpuModels",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "A 100 Series");

            migrationBuilder.UpdateData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "DirectX Optimisations for Vigus Graphics", "D3d Optimizations" });

            migrationBuilder.UpdateData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Boost performance with minimal resolution change", "VigusBoost" });

            migrationBuilder.UpdateData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cores", "Description", "MemorySize", "ModelId", "Name", "ReleaseDate", "Tdp" },
                values: new object[] { 6000, "High-end GPU that is ready to game and compute. Built by Vigus.", 18, 4, "C98X", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 300 });

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "C Series");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "B Series");

            migrationBuilder.UpdateData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "A Series");

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_Name",
                table: "Gpus",
                column: "Name",
                unique: true);
        }
    }
}
