using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GpuTechnologies_Name",
                table: "GpuTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_Gpus_Name",
                table: "Gpus");

            migrationBuilder.DropIndex(
                name: "IX_DriverVersions_Name",
                table: "DriverVersions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GpuTechnologies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Gpus",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gpus",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DriverVersions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "GpuTechnologies",
                columns: new[] { "Id", "Description", "ImageId", "Name" },
                values: new object[,]
                {
                    { 2, "DirectX Optimisations for Vigus Graphics", null, "D3d Optimizations" },
                    { 3, "Boost performance with minimal resolution change", null, "VigusBoost" }
                });

            migrationBuilder.UpdateData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Title" },
                values: new object[] { "defaultimage128x128.png", "defaultimage 128x128" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Name", "Title" },
                values: new object[] { 3, "defaultimage496x250.png", "defaultimage 496x250" });

            migrationBuilder.CreateIndex(
                name: "IX_GpuTechnologies_Name",
                table: "GpuTechnologies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_Name",
                table: "Gpus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriverVersions_Name",
                table: "DriverVersions",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GpuTechnologies_Name",
                table: "GpuTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_Gpus_Name",
                table: "Gpus");

            migrationBuilder.DropIndex(
                name: "IX_DriverVersions_Name",
                table: "DriverVersions");

            migrationBuilder.DeleteData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GpuTechnologies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GpuTechnologies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Gpus",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gpus",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DriverVersions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Title" },
                values: new object[] { "defaulttechnology.png", "Default TechnologyImage" });

            migrationBuilder.CreateIndex(
                name: "IX_GpuTechnologies_Name",
                table: "GpuTechnologies",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gpus_Name",
                table: "Gpus",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DriverVersions_Name",
                table: "DriverVersions",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }
    }
}
