using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetforum.DAL.Migrations
{
    public partial class cretions_db_St : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Creation_CreationId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Creation",
                table: "Creation");

            migrationBuilder.RenameTable(
                name: "Creation",
                newName: "Creations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Creations",
                table: "Creations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Creations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 5, 13, 10, 51, 40, 790, DateTimeKind.Local).AddTicks(8893));

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Creations_CreationId",
                table: "Reviews",
                column: "CreationId",
                principalTable: "Creations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Creations_CreationId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Creations",
                table: "Creations");

            migrationBuilder.RenameTable(
                name: "Creations",
                newName: "Creation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Creation",
                table: "Creation",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Creation",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2019, 5, 13, 10, 49, 44, 602, DateTimeKind.Local).AddTicks(7556));

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Creation_CreationId",
                table: "Reviews",
                column: "CreationId",
                principalTable: "Creation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
