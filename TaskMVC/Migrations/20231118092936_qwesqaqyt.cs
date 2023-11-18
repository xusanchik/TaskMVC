using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class qwesqaqyt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "94536e7e-f744-482a-b767-66a0bb2de0a1", null, "USER", "USER" },
                    { "ccba0276-906c-49a0-91b8-267e2c454bb6", null, "ADMIN", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "7b6c7305-f82f-408f-b501-ee2946a192a5", null, "USER", "USER" },
                    { "cdfd6adf-212e-4529-bbc9-c3f67cc14a02", null, "ADMIN", "ADMIN" }
                });
        }
    }
}
