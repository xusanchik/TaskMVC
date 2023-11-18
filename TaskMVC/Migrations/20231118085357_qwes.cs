﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class qwes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "a3bb227c-b220-417f-aed7-3377c9af0cd0", null, "ADMIN", "ADMIN" },
                    { "b2d8bc08-20f1-4d3b-862e-184e98843886", null, "USER", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "7b73d91f-a719-490a-a363-c4cb6deadac1", null, "USER", "USER" },
                    { "e1d98811-5a2d-482f-8e39-8add3488a184", null, "ADMIN", "ADMIN" }
                });
        }
    }
}
