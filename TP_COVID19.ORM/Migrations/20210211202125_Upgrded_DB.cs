using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_COVID19.ORM.Migrations
{
    public partial class Upgrded_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateNaissance",
                table: "Personnes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateNaissance",
                table: "Personnes");
        }
    }
}
