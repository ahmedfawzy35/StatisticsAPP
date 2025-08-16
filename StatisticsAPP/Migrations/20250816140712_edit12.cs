using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class edit12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sapeks_CaseYears_CaseYearId",
                table: "Sapeks");

            migrationBuilder.DropForeignKey(
                name: "FK_Sapeks_delayCacesForMonthTypes_DelayCacesForMonthTypeId",
                table: "Sapeks");

            migrationBuilder.DropIndex(
                name: "IX_Sapeks_CaseYearId",
                table: "Sapeks");

            migrationBuilder.DropIndex(
                name: "IX_Sapeks_DelayCacesForMonthTypeId",
                table: "Sapeks");

            migrationBuilder.DropColumn(
                name: "CaseYearId",
                table: "Sapeks");

            migrationBuilder.DropColumn(
                name: "DelayCacesForMonthTypeId",
                table: "Sapeks");

            migrationBuilder.CreateIndex(
                name: "IX_Sapeks_IdCaseYear",
                table: "Sapeks",
                column: "IdCaseYear");

            migrationBuilder.AddForeignKey(
                name: "FK_Sapeks_CaseYears_IdCaseYear",
                table: "Sapeks",
                column: "IdCaseYear",
                principalTable: "CaseYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sapeks_CaseYears_IdCaseYear",
                table: "Sapeks");

            migrationBuilder.DropIndex(
                name: "IX_Sapeks_IdCaseYear",
                table: "Sapeks");

            migrationBuilder.AddColumn<int>(
                name: "CaseYearId",
                table: "Sapeks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DelayCacesForMonthTypeId",
                table: "Sapeks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sapeks_CaseYearId",
                table: "Sapeks",
                column: "CaseYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Sapeks_DelayCacesForMonthTypeId",
                table: "Sapeks",
                column: "DelayCacesForMonthTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sapeks_CaseYears_CaseYearId",
                table: "Sapeks",
                column: "CaseYearId",
                principalTable: "CaseYears",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sapeks_delayCacesForMonthTypes_DelayCacesForMonthTypeId",
                table: "Sapeks",
                column: "DelayCacesForMonthTypeId",
                principalTable: "delayCacesForMonthTypes",
                principalColumn: "Id");
        }
    }
}
