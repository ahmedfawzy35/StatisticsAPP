using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class editcircletable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CircleCategoryId",
                table: "Circles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCircleCategory",
                table: "Circles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSupCourt",
                table: "Circles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupCourtId",
                table: "Circles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CircleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircleCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircleCategories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Circles_CircleCategoryId",
                table: "Circles",
                column: "CircleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Circles_SupCourtId",
                table: "Circles",
                column: "SupCourtId");

            migrationBuilder.CreateIndex(
                name: "IX_CircleCategories_UserId",
                table: "CircleCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Circles_CircleCategories_CircleCategoryId",
                table: "Circles",
                column: "CircleCategoryId",
                principalTable: "CircleCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Circles_SupCourts_SupCourtId",
                table: "Circles",
                column: "SupCourtId",
                principalTable: "SupCourts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Circles_CircleCategories_CircleCategoryId",
                table: "Circles");

            migrationBuilder.DropForeignKey(
                name: "FK_Circles_SupCourts_SupCourtId",
                table: "Circles");

            migrationBuilder.DropTable(
                name: "CircleCategories");

            migrationBuilder.DropIndex(
                name: "IX_Circles_CircleCategoryId",
                table: "Circles");

            migrationBuilder.DropIndex(
                name: "IX_Circles_SupCourtId",
                table: "Circles");

            migrationBuilder.DropColumn(
                name: "CircleCategoryId",
                table: "Circles");

            migrationBuilder.DropColumn(
                name: "IdCircleCategory",
                table: "Circles");

            migrationBuilder.DropColumn(
                name: "IdSupCourt",
                table: "Circles");

            migrationBuilder.DropColumn(
                name: "SupCourtId",
                table: "Circles");
        }
    }
}
