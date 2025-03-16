using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class editusersupcourts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSupCourts_SupCourts_SuperCourtId",
                table: "UserSupCourts");

            migrationBuilder.RenameColumn(
                name: "SuperCourtId",
                table: "UserSupCourts",
                newName: "SupCourtId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSupCourts_SuperCourtId",
                table: "UserSupCourts",
                newName: "IX_UserSupCourts_SupCourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSupCourts_SupCourts_SupCourtId",
                table: "UserSupCourts",
                column: "SupCourtId",
                principalTable: "SupCourts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSupCourts_SupCourts_SupCourtId",
                table: "UserSupCourts");

            migrationBuilder.RenameColumn(
                name: "SupCourtId",
                table: "UserSupCourts",
                newName: "SuperCourtId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSupCourts_SupCourtId",
                table: "UserSupCourts",
                newName: "IX_UserSupCourts_SuperCourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSupCourts_SupCourts_SuperCourtId",
                table: "UserSupCourts",
                column: "SuperCourtId",
                principalTable: "SupCourts",
                principalColumn: "Id");
        }
    }
}
