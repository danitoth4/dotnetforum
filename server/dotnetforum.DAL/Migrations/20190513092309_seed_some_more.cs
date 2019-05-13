using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetforum.DAL.Migrations
{
    public partial class seed_some_more : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Creations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 13, 11, 23, 9, 468, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.InsertData(
                table: "Creations",
                columns: new[] { "Id", "CreatedAt", "Description", "Title", "creation_type", "Author" },
                values: new object[] { 2, new DateTime(2018, 5, 13, 11, 23, 9, 471, DateTimeKind.Local).AddTicks(2033), "this is a good movie", "Movie title", "type_book", null });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "CreationId", "Rating", "UserId", "WritenAt" },
                values: new object[] { 1, "this is a review bout a book", 1, 4, 1, new DateTime(2019, 4, 23, 11, 23, 9, 471, DateTimeKind.Local).AddTicks(9596) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "ReviewId", "UserId", "WritenAt" },
                values: new object[] { 1, "yo mate good review you did there i agree", 1, 2, new DateTime(2019, 5, 9, 11, 23, 9, 472, DateTimeKind.Local).AddTicks(5316) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "ReviewId", "UserId", "WritenAt" },
                values: new object[] { 2, "thanks", 1, 1, new DateTime(2019, 5, 11, 11, 23, 9, 472, DateTimeKind.Local).AddTicks(6019) });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "CreationId", "Rating", "UserId", "WritenAt" },
                values: new object[] { 2, "this is a review bout a movie", 2, 2, 2, new DateTime(2019, 5, 10, 11, 23, 9, 472, DateTimeKind.Local).AddTicks(1037) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "ReviewId", "UserId", "WritenAt" },
                values: new object[] { 3, "yo mate bad review you did there i disagree", 2, 1, new DateTime(2019, 5, 12, 11, 23, 9, 472, DateTimeKind.Local).AddTicks(6031) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Creations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Creations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 5, 13, 10, 51, 40, 790, DateTimeKind.Local).AddTicks(8893));
        }
    }
}
