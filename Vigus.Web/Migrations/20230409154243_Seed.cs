using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Vigus.Web.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OsVersions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "GpuTechnologies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Gpus",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "v1.0.2");

            migrationBuilder.InsertData(
                table: "DriverVersions",
                columns: new[] { "Id", "Description", "FixedChanges", "KnownIssues", "Name" },
                values: new object[] { 2, "Added support for more variety of GPUs", "Low performance fixed", "Random crash may occur", "v1.1.0" });

            migrationBuilder.InsertData(
                table: "Gpus",
                columns: new[] { "Id", "Cores", "Description", "ImageId", "MemorySize", "ModelId", "Name", "Price", "Tdp" },
                values: new object[] { 1, 6000, "High-end GPU that is ready to game and compute. Built by Vigus.", 1, 18, 4, "C98X", 899.99m, 300 });

            migrationBuilder.InsertData(
                table: "OsVersions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Windows 7" },
                    { 2, "Windows 8" },
                    { 3, "Windows 10" },
                    { 4, "Windows 11" },
                    { 5, "Ubuntu" },
                    { 6, "Linux Mint" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GpuTechnologies_ImageId",
                table: "GpuTechnologies",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_GpuTechnologies_GpuImages_ImageId",
                table: "GpuTechnologies",
                column: "ImageId",
                principalTable: "GpuImages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GpuTechnologies_GpuImages_ImageId",
                table: "GpuTechnologies");

            migrationBuilder.DropIndex(
                name: "IX_GpuTechnologies_ImageId",
                table: "GpuTechnologies");

            migrationBuilder.DeleteData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gpus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OsVersions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OsVersions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OsVersions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OsVersions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OsVersions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OsVersions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "GpuTechnologies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "OsVersions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.UpdateData(
                table: "DriverVersions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Vigus Driver Software v1.0.2");
        }
    }
}
