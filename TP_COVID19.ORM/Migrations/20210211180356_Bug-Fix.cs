using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_COVID19.ORM.Migrations
{
    public partial class BugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Statut = table.Column<bool>(type: "INTEGER", nullable: false),
                    Sexe = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vaccins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PatientID = table.Column<int>(type: "INTEGER", nullable: true),
                    VaccinID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Personnes_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Personnes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Vaccins_VaccinID",
                        column: x => x.VaccinID,
                        principalTable: "Vaccins",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_PatientID",
                table: "Vaccinations",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccinID",
                table: "Vaccinations",
                column: "VaccinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Vaccins");
        }
    }
}
