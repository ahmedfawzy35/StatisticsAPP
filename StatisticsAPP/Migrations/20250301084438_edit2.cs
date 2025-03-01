using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class edit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "SupCourts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFather",
                table: "DecisionCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CircleId",
                table: "CircleStatistics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DayOfWork",
                table: "CircleStatistics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "CircleStatistics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CircleStatistics_CircleId",
                table: "CircleStatistics",
                column: "CircleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CircleStatistics_Circles_CircleId",
                table: "CircleStatistics",
                column: "CircleId",
                principalTable: "Circles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CircleStatistics_Circles_CircleId",
                table: "CircleStatistics");

            migrationBuilder.DropIndex(
                name: "IX_CircleStatistics_CircleId",
                table: "CircleStatistics");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "SupCourts");

            migrationBuilder.DropColumn(
                name: "IsFather",
                table: "DecisionCategories");

            migrationBuilder.DropColumn(
                name: "CircleId",
                table: "CircleStatistics");

            migrationBuilder.DropColumn(
                name: "DayOfWork",
                table: "CircleStatistics");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "CircleStatistics");
        }
    }
}
