using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class qwesqa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3bb227c-b220-417f-aed7-3377c9af0cd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2d8bc08-20f1-4d3b-862e-184e98843886");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b7e93ac-dee5-43ea-ad2f-2f9e8ea9b75c", null, "ADMIN", "ADMIN" },
                    { "3ec7064f-7885-4934-a07d-9d928ed11f74", null, "USER", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b7e93ac-dee5-43ea-ad2f-2f9e8ea9b75c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ec7064f-7885-4934-a07d-9d928ed11f74");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3bb227c-b220-417f-aed7-3377c9af0cd0", null, "ADMIN", "ADMIN" },
                    { "b2d8bc08-20f1-4d3b-862e-184e98843886", null, "USER", "USER" }
                });
        }
    }
}
