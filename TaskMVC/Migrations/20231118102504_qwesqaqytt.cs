using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class qwesqaqytt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94536e7e-f744-482a-b767-66a0bb2de0a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccba0276-906c-49a0-91b8-267e2c454bb6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0146c85b-7d02-4846-b65d-ac50fc5d3b6d", null, "ADMIN", "ADMIN" },
                    { "4b0d1bf5-a9ef-431b-a954-55723ac21e3a", null, "USER", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0146c85b-7d02-4846-b65d-ac50fc5d3b6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b0d1bf5-a9ef-431b-a954-55723ac21e3a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94536e7e-f744-482a-b767-66a0bb2de0a1", null, "USER", "USER" },
                    { "ccba0276-906c-49a0-91b8-267e2c454bb6", null, "ADMIN", "ADMIN" }
                });
        }
    }
}
