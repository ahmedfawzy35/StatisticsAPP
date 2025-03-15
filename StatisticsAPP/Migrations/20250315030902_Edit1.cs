using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class Edit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticsDecisions_CaseYear_CaseYearId",
                table: "StatisticsDecisions");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticsDelayCases_CaseYear_CaseYearId",
                table: "StatisticsDelayCases");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticsInterCases_CaseYear_CaseYearId",
                table: "StatisticsInterCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseYear",
                table: "CaseYear");

            migrationBuilder.RenameTable(
                name: "CaseYear",
                newName: "CaseYears");

            migrationBuilder.AddColumn<bool>(
                name: "IsFather",
                table: "InterCasesCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseYears",
                table: "CaseYears",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Shortenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IdCircleStatistics = table.Column<int>(type: "int", nullable: false),
                    CircleStatisticsId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shortenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shortenings_CircleStatistics_CircleStatisticsId",
                        column: x => x.CircleStatisticsId,
                        principalTable: "CircleStatistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shortenings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shortenings_CircleStatisticsId",
                table: "Shortenings",
                column: "CircleStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shortenings_UserId",
                table: "Shortenings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticsDecisions_CaseYears_CaseYearId",
                table: "StatisticsDecisions",
                column: "CaseYearId",
                principalTable: "CaseYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticsDelayCases_CaseYears_CaseYearId",
                table: "StatisticsDelayCases",
                column: "CaseYearId",
                principalTable: "CaseYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticsInterCases_CaseYears_CaseYearId",
                table: "StatisticsInterCases",
                column: "CaseYearId",
                principalTable: "CaseYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatisticsDecisions_CaseYears_CaseYearId",
                table: "StatisticsDecisions");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticsDelayCases_CaseYears_CaseYearId",
                table: "StatisticsDelayCases");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticsInterCases_CaseYears_CaseYearId",
                table: "StatisticsInterCases");

            migrationBuilder.DropTable(
                name: "Shortenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseYears",
                table: "CaseYears");

            migrationBuilder.DropColumn(
                name: "IsFather",
                table: "InterCasesCategories");

            migrationBuilder.RenameTable(
                name: "CaseYears",
                newName: "CaseYear");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseYear",
                table: "CaseYear",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticsDecisions_CaseYear_CaseYearId",
                table: "StatisticsDecisions",
                column: "CaseYearId",
                principalTable: "CaseYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticsDelayCases_CaseYear_CaseYearId",
                table: "StatisticsDelayCases",
                column: "CaseYearId",
                principalTable: "CaseYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticsInterCases_CaseYear_CaseYearId",
                table: "StatisticsInterCases",
                column: "CaseYearId",
                principalTable: "CaseYear",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
