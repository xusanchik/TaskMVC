using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class qwertyu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f1299f1-c382-4155-bc5d-2650f2577e0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41143f80-89d2-4baa-99a1-c37891f15833");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7b73d91f-a719-490a-a363-c4cb6deadac1", null, "USER", "USER" },
                    { "e1d98811-5a2d-482f-8e39-8add3488a184", null, "ADMIN", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b73d91f-a719-490a-a363-c4cb6deadac1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1d98811-5a2d-482f-8e39-8add3488a184");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f1299f1-c382-4155-bc5d-2650f2577e0b", null, "USER", "USER" },
                    { "41143f80-89d2-4baa-99a1-c37891f15833", null, "ADMIN", "ADMIN" }
                });
        }
    }
}
