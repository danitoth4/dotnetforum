using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetforum.DAL.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Creation",
                columns: new[] { "Id", "CreatedAt", "Description", "Discriminator", "Title", "Author" },
                values: new object[] { 1, new DateTime(2019, 5, 7, 15, 22, 51, 849, DateTimeKind.Local).AddTicks(186), "yo", "Book", "ttl", "mr. author" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Creation",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
