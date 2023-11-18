using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class qwesqaq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "7b6c7305-f82f-408f-b501-ee2946a192a5", null, "USER", "USER" },
                    { "cdfd6adf-212e-4529-bbc9-c3f67cc14a02", null, "ADMIN", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b6c7305-f82f-408f-b501-ee2946a192a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdfd6adf-212e-4529-bbc9-c3f67cc14a02");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b7e93ac-dee5-43ea-ad2f-2f9e8ea9b75c", null, "ADMIN", "ADMIN" },
                    { "3ec7064f-7885-4934-a07d-9d928ed11f74", null, "USER", "USER" }
                });
        }
    }
}
