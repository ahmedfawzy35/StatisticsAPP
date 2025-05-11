using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class editDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelayCacesForMonths_delayCacesForMonthTypes_IdDelayCacesForMonthTypeId",
                table: "DelayCacesForMonths");

            migrationBuilder.RenameColumn(
                name: "IdDelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                newName: "DelayCacesForMonthTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DelayCacesForMonths_IdDelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                newName: "IX_DelayCacesForMonths_DelayCacesForMonthTypeId");

            migrationBuilder.AddColumn<int>(
                name: "CaseYearId",
                table: "Shortenings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCaseYear",
                table: "DelayCacesForMonths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountCaseYear",
                table: "CircleStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "CircleStatistics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndCaseYear",
                table: "CircleStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartCaseYear",
                table: "CircleStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "CircleDays",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "CaseYears",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "StatisticsDeleteds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCircleStatistics = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CaseYearId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticsDeleteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticsDeleteds_CaseYears_CaseYearId",
                        column: x => x.CaseYearId,
                        principalTable: "CaseYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatisticsDeleteds_CircleStatistics_IdCircleStatistics",
                        column: x => x.IdCircleStatistics,
                        principalTable: "CircleStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatisticsDeleteds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shortenings_CaseYearId",
                table: "Shortenings",
                column: "CaseYearId");

            migrationBuilder.CreateIndex(
                name: "IX_DelayCacesForMonths_IdCaseYear",
                table: "DelayCacesForMonths",
                column: "IdCaseYear");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDeleteds_CaseYearId",
                table: "StatisticsDeleteds",
                column: "CaseYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDeleteds_IdCircleStatistics",
                table: "StatisticsDeleteds",
                column: "IdCircleStatistics");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDeleteds_UserId",
                table: "StatisticsDeleteds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DelayCacesForMonths_CaseYears_IdCaseYear",
                table: "DelayCacesForMonths",
                column: "IdCaseYear",
                principalTable: "CaseYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DelayCacesForMonths_delayCacesForMonthTypes_DelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                column: "DelayCacesForMonthTypeId",
                principalTable: "delayCacesForMonthTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shortenings_CaseYears_CaseYearId",
                table: "Shortenings",
                column: "CaseYearId",
                principalTable: "CaseYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelayCacesForMonths_CaseYears_IdCaseYear",
                table: "DelayCacesForMonths");

            migrationBuilder.DropForeignKey(
                name: "FK_DelayCacesForMonths_delayCacesForMonthTypes_DelayCacesForMonthTypeId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropForeignKey(
                name: "FK_Shortenings_CaseYears_CaseYearId",
                table: "Shortenings");

            migrationBuilder.DropTable(
                name: "StatisticsDeleteds");

            migrationBuilder.DropIndex(
                name: "IX_Shortenings_CaseYearId",
                table: "Shortenings");

            migrationBuilder.DropIndex(
                name: "IX_DelayCacesForMonths_IdCaseYear",
                table: "DelayCacesForMonths");

            migrationBuilder.DropColumn(
                name: "CaseYearId",
                table: "Shortenings");

            migrationBuilder.DropColumn(
                name: "IdCaseYear",
                table: "DelayCacesForMonths");

            migrationBuilder.DropColumn(
                name: "CountCaseYear",
                table: "CircleStatistics");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "CircleStatistics");

            migrationBuilder.DropColumn(
                name: "EndCaseYear",
                table: "CircleStatistics");

            migrationBuilder.DropColumn(
                name: "StartCaseYear",
                table: "CircleStatistics");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "CircleDays");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "CaseYears");

            migrationBuilder.RenameColumn(
                name: "DelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                newName: "IdDelayCacesForMonthTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DelayCacesForMonths_DelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                newName: "IX_DelayCacesForMonths_IdDelayCacesForMonthTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DelayCacesForMonths_delayCacesForMonthTypes_IdDelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                column: "IdDelayCacesForMonthTypeId",
                principalTable: "delayCacesForMonthTypes",
                principalColumn: "Id");
        }
    }
}
