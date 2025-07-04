using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class Add_Sapek_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mokamam",
                table: "CircleStatistics");

            migrationBuilder.AddColumn<bool>(
                name: "IsNew",
                table: "CircleStatistics",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.CreateTable(
                name: "Sapeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCircleStatistics = table.Column<int>(type: "int", nullable: false),
                    IdCircleDay = table.Column<int>(type: "int", nullable: false),
                    IdCaseYear = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CaseYearId = table.Column<int>(type: "int", nullable: true),
                    DelayCacesForMonthTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sapeks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sapeks_CaseYears_CaseYearId",
                        column: x => x.CaseYearId,
                        principalTable: "CaseYears",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sapeks_CircleDays_IdCircleDay",
                        column: x => x.IdCircleDay,
                        principalTable: "CircleDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sapeks_CircleStatistics_IdCircleStatistics",
                        column: x => x.IdCircleStatistics,
                        principalTable: "CircleStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sapeks_delayCacesForMonthTypes_DelayCacesForMonthTypeId",
                        column: x => x.DelayCacesForMonthTypeId,
                        principalTable: "delayCacesForMonthTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sapeks_CaseYearId",
                table: "Sapeks",
                column: "CaseYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Sapeks_DelayCacesForMonthTypeId",
                table: "Sapeks",
                column: "DelayCacesForMonthTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sapeks_IdCircleDay",
                table: "Sapeks",
                column: "IdCircleDay");

            migrationBuilder.CreateIndex(
                name: "IX_Sapeks_IdCircleStatistics",
                table: "Sapeks",
                column: "IdCircleStatistics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sapeks");

            migrationBuilder.DropColumn(
                name: "IsNew",
                table: "CircleStatistics");

            migrationBuilder.AddColumn<int>(
                name: "Mokamam",
                table: "CircleStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
