using Microsoft.EntityFrameworkCore.Migrations;

namespace TP_COVID19.ORM.Migrations
{
    public partial class ajoutID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Personnes_PatientID",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Vaccins_VaccinID",
                table: "Vaccinations");

            migrationBuilder.RenameColumn(
                name: "VaccinID",
                table: "Vaccinations",
                newName: "IDVaccinID");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Vaccinations",
                newName: "IDPatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccinations_VaccinID",
                table: "Vaccinations",
                newName: "IX_Vaccinations_IDVaccinID");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccinations_PatientID",
                table: "Vaccinations",
                newName: "IX_Vaccinations_IDPatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Personnes_IDPatientID",
                table: "Vaccinations",
                column: "IDPatientID",
                principalTable: "Personnes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Vaccins_IDVaccinID",
                table: "Vaccinations",
                column: "IDVaccinID",
                principalTable: "Vaccins",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Personnes_IDPatientID",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Vaccins_IDVaccinID",
                table: "Vaccinations");

            migrationBuilder.RenameColumn(
                name: "IDVaccinID",
                table: "Vaccinations",
                newName: "VaccinID");

            migrationBuilder.RenameColumn(
                name: "IDPatientID",
                table: "Vaccinations",
                newName: "PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccinations_IDVaccinID",
                table: "Vaccinations",
                newName: "IX_Vaccinations_VaccinID");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccinations_IDPatientID",
                table: "Vaccinations",
                newName: "IX_Vaccinations_PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Personnes_PatientID",
                table: "Vaccinations",
                column: "PatientID",
                principalTable: "Personnes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Vaccins_VaccinID",
                table: "Vaccinations",
                column: "VaccinID",
                principalTable: "Vaccins",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
