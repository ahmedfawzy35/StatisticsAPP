using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class editJudjes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CircleJudgeId",
                table: "StatisticsDecisions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Judges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CircleDayId",
                table: "DelayCacesForMonths",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CircleStatisticsId",
                table: "DelayCacesForMonths",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCircleDay",
                table: "DelayCacesForMonths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCircleStatistics",
                table: "DelayCacesForMonths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDecisions_CircleJudgeId",
                table: "StatisticsDecisions",
                column: "CircleJudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_DelayCacesForMonths_CircleDayId",
                table: "DelayCacesForMonths",
                column: "CircleDayId");

            migrationBuilder.CreateIndex(
                name: "IX_DelayCacesForMonths_CircleStatisticsId",
                table: "DelayCacesForMonths",
                column: "CircleStatisticsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DelayCacesForMonths_CircleDays_CircleDayId",
                table: "DelayCacesForMonths",
                column: "CircleDayId",
                principalTable: "CircleDays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DelayCacesForMonths_CircleStatistics_CircleStatisticsId",
                table: "DelayCacesForMonths",
                column: "CircleStatisticsId",
                principalTable: "CircleStatistics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticsDecisions_CircleJudges_CircleJudgeId",
                table: "StatisticsDecisions",
                column: "CircleJudgeId",
                principalTable: "CircleJudges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelayCacesForMonths_CircleDays_CircleDayId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropForeignKey(
                name: "FK_DelayCacesForMonths_CircleStatistics_CircleStatisticsId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticsDecisions_CircleJudges_CircleJudgeId",
                table: "StatisticsDecisions");

            migrationBuilder.DropIndex(
                name: "IX_StatisticsDecisions_CircleJudgeId",
                table: "StatisticsDecisions");

            migrationBuilder.DropIndex(
                name: "IX_DelayCacesForMonths_CircleDayId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropIndex(
                name: "IX_DelayCacesForMonths_CircleStatisticsId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropColumn(
                name: "CircleJudgeId",
                table: "StatisticsDecisions");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Judges");

            migrationBuilder.DropColumn(
                name: "CircleDayId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropColumn(
                name: "CircleStatisticsId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropColumn(
                name: "IdCircleDay",
                table: "DelayCacesForMonths");

            migrationBuilder.DropColumn(
                name: "IdCircleStatistics",
                table: "DelayCacesForMonths");
        }
    }
}
