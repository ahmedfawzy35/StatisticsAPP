using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class add_DelayCacesForMonthType_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "delayCacesForMonthTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delayCacesForMonthTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DelayCacesForMonths_IdDelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                column: "IdDelayCacesForMonthTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DelayCacesForMonths_delayCacesForMonthTypes_IdDelayCacesForMonthTypeId",
                table: "DelayCacesForMonths",
                column: "IdDelayCacesForMonthTypeId",
                principalTable: "delayCacesForMonthTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelayCacesForMonths_delayCacesForMonthTypes_IdDelayCacesForMonthTypeId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropTable(
                name: "delayCacesForMonthTypes");

            migrationBuilder.DropIndex(
                name: "IX_DelayCacesForMonths_IdDelayCacesForMonthTypeId",
                table: "DelayCacesForMonths");

            migrationBuilder.DropColumn(
                name: "IdDelayCacesForMonthTypeId",
                table: "DelayCacesForMonths");
        }
    }
}
