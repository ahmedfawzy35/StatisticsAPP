using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class EditCircleDAY : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "CircleDays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "CircleDays");
        }
    }
}
