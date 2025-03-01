using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class addusercourts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCircles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCircle = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    CircleId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCircles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCircles_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCircles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSupCourts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSupCourt = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    SuperCourtId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSupCourts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSupCourts_SupCourts_SuperCourtId",
                        column: x => x.SuperCourtId,
                        principalTable: "SupCourts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSupCourts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSuperCourts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSuperCourt = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    SuperCourtId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSuperCourts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSuperCourts_SuperCourts_SuperCourtId",
                        column: x => x.SuperCourtId,
                        principalTable: "SuperCourts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSuperCourts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCircles_CircleId",
                table: "UserCircles",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCircles_UserId",
                table: "UserCircles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSupCourts_SuperCourtId",
                table: "UserSupCourts",
                column: "SuperCourtId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSupCourts_UserId",
                table: "UserSupCourts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSuperCourts_SuperCourtId",
                table: "UserSuperCourts",
                column: "SuperCourtId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSuperCourts_UserId",
                table: "UserSuperCourts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCircles");

            migrationBuilder.DropTable(
                name: "UserSupCourts");

            migrationBuilder.DropTable(
                name: "UserSuperCourts");
        }
    }
}
