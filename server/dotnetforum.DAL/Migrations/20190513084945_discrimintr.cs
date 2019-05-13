using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetforum.DAL.Migrations
{
    public partial class discrimintr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Creation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Creation",
                newName: "creation_type");

            migrationBuilder.InsertData(
                table: "Creation",
                columns: new[] { "Id", "CreatedAt", "Description", "Title", "creation_type", "Author" },
                values: new object[] { 1, new DateTime(2019, 5, 13, 10, 49, 44, 602, DateTimeKind.Local).AddTicks(7556), "yo", "ttl", "type_book", "mr. author" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Creation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "creation_type",
                table: "Creation",
                newName: "Discriminator");

            migrationBuilder.InsertData(
                table: "Creation",
                columns: new[] { "Id", "CreatedAt", "Description", "Discriminator", "Title", "Author" },
                values: new object[] { 1, new DateTime(2019, 5, 10, 23, 37, 27, 321, DateTimeKind.Local).AddTicks(5933), "yo", "Book", "ttl", "mr. author" });
        }
    }
}
