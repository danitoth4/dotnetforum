using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetforum.DAL.Migrations
{
    public partial class Configuring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Creation",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 5, 10, 23, 37, 27, 321, DateTimeKind.Local).AddTicks(5933));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Creation",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 5, 10, 21, 11, 56, 320, DateTimeKind.Local).AddTicks(7360));
        }
    }
}
