using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class editTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelayCacesForMonths_delayCacesForMonthTypes_DelayCacesForMonthTypeId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropIndex(
                name: "IX_DelayCacesForMonths_DelayCacesForMonthTypeId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropColumn(
                name: "DelayCacesForMonthTypeId",
                table: "DelayCacesForMonths");

            migrationBuilder.AddColumn<int>(
                name: "IdDelayCacesForMonthType",
                table: "DelayCacesForMonths",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DelayCacesForMonths_IdDelayCacesForMonthType",
                table: "DelayCacesForMonths",
                column: "IdDelayCacesForMonthType");

            migrationBuilder.AddForeignKey(
                name: "FK_DelayCacesForMonths_delayCacesForMonthTypes_IdDelayCacesForMonthType",
                table: "DelayCacesForMonths",
                column: "IdDelayCacesForMonthType",
                principalTable: "delayCacesForMonthTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelayCacesForMonths_delayCacesForMonthTypes_IdDelayCacesForMonthType",
                table: "DelayCacesForMonths");

            migrationBuilder.DropIndex(
                name: "IX_DelayCacesForMonths_IdDelayCacesForMonthType",
                table: "DelayCacesForMonths");

            migrationBuilder.DropColumn(
                name: "IdDelayCacesForMonthType",
                table: "DelayCacesForMonths");

            migrationBuilder.AddColumn<int>(
                name: "DelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DelayCacesForMonths_DelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                column: "DelayCacesForMonthTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DelayCacesForMonths_delayCacesForMonthTypes_DelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                column: "DelayCacesForMonthTypeId",
                principalTable: "delayCacesForMonthTypes",
                principalColumn: "Id");
        }
    }
}
