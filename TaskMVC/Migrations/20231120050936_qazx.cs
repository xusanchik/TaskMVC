using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class qazx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "45d7eca4-8320-4d9a-8027-e5aa5b9dbdec", null, "USER", "USER" },
                    { "8311454d-afe4-49a2-9b57-3bc8590fc17d", null, "ADMIN", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45d7eca4-8320-4d9a-8027-e5aa5b9dbdec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8311454d-afe4-49a2-9b57-3bc8590fc17d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0146c85b-7d02-4846-b65d-ac50fc5d3b6d", null, "ADMIN", "ADMIN" },
                    { "4b0d1bf5-a9ef-431b-a954-55723ac21e3a", null, "USER", "USER" }
                });
        }
    }
}
