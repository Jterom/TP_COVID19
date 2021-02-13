using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_COVID19.ORM.Migrations
{
    public partial class ajoutRappel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Rappel",
                table: "Vaccinations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rappel",
                table: "Vaccinations");
        }
    }
}
