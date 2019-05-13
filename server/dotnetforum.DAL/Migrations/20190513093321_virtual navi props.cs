using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetforum.DAL.Migrations
{
    public partial class virtualnaviprops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "WritenAt",
                value: new DateTime(2019, 5, 9, 11, 33, 20, 363, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "WritenAt",
                value: new DateTime(2019, 5, 11, 11, 33, 20, 363, DateTimeKind.Local).AddTicks(9859));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "WritenAt",
                value: new DateTime(2019, 5, 12, 11, 33, 20, 363, DateTimeKind.Local).AddTicks(9870));

            migrationBuilder.UpdateData(
                table: "Creations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 13, 11, 33, 20, 359, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "Creations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2018, 5, 13, 11, 33, 20, 362, DateTimeKind.Local).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "WritenAt",
                value: new DateTime(2019, 4, 23, 11, 33, 20, 363, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "WritenAt",
                value: new DateTime(2019, 5, 10, 11, 33, 20, 363, DateTimeKind.Local).AddTicks(4546));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "WritenAt",
                value: new DateTime(2019, 5, 9, 11, 23, 9, 472, DateTimeKind.Local).AddTicks(5316));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "WritenAt",
                value: new DateTime(2019, 5, 11, 11, 23, 9, 472, DateTimeKind.Local).AddTicks(6019));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "WritenAt",
                value: new DateTime(2019, 5, 12, 11, 23, 9, 472, DateTimeKind.Local).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "Creations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 2, 13, 11, 23, 9, 468, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.UpdateData(
                table: "Creations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2018, 5, 13, 11, 23, 9, 471, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "WritenAt",
                value: new DateTime(2019, 4, 23, 11, 23, 9, 471, DateTimeKind.Local).AddTicks(9596));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "WritenAt",
                value: new DateTime(2019, 5, 10, 11, 23, 9, 472, DateTimeKind.Local).AddTicks(1037));
        }
    }
}
