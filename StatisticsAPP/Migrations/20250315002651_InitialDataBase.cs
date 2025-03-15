using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StatisticsAPP.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IsOld = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseYear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DelayCacesForMonths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelayCacesForMonths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Circles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Circles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CircleTypes",
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
                    table.PrimaryKey("PK_CircleTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircleTypes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DecisionCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    IsFather = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecisionCategories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DelayCases",
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
                    table.PrimaryKey("PK_DelayCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DelayCases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "InterCasesCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterCasesCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterCasesCategories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Judges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeniorityNumber = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Judges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Judges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SuperCourts",
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
                    table.PrimaryKey("PK_SuperCourts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperCourts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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
                name: "CircleDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CircleTypeId = table.Column<int>(type: "int", nullable: false),
                    CircleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircleDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircleDays_CircleTypes_CircleTypeId",
                        column: x => x.CircleTypeId,
                        principalTable: "CircleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CircleDays_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Decisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDecisionCategory = table.Column<int>(type: "int", nullable: false),
                    DecisionCategoryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Decisions_DecisionCategories_DecisionCategoryId",
                        column: x => x.DecisionCategoryId,
                        principalTable: "DecisionCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Decisions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "InterCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdInterCasesCategory = table.Column<int>(type: "int", nullable: false),
                    InterCasesCategoryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterCases_InterCasesCategories_InterCasesCategoryId",
                        column: x => x.InterCasesCategoryId,
                        principalTable: "InterCasesCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InterCases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "CircleJudges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCircle = table.Column<int>(type: "int", nullable: false),
                    IdJudge = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CircleId = table.Column<int>(type: "int", nullable: true),
                    JudgeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircleJudges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircleJudges_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CircleJudges_Circles_IdCircle",
                        column: x => x.IdCircle,
                        principalTable: "Circles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CircleJudges_Judges_IdJudge",
                        column: x => x.IdJudge,
                        principalTable: "Judges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CircleJudges_Judges_JudgeId",
                        column: x => x.JudgeId,
                        principalTable: "Judges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CircleJudges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RoleOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdOperation = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleOperations_Operations_IdOperation",
                        column: x => x.IdOperation,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RoleOperations_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleOperations_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RoleOperations_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleOperations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserCreatedId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupCourts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperCourtId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupCourts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupCourts_SuperCourts_SuperCourtId",
                        column: x => x.SuperCourtId,
                        principalTable: "SuperCourts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SupCourts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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

            migrationBuilder.CreateTable(
                name: "CircleStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCircleDay = table.Column<int>(type: "int", nullable: false),
                    DayOfWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    CircleDayId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircleStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CircleStatistics_CircleDays_CircleDayId",
                        column: x => x.CircleDayId,
                        principalTable: "CircleDays",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CircleStatistics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                name: "StatisticsDecisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCircleStatistics = table.Column<int>(type: "int", nullable: false),
                    IdDecision = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CaseYearId = table.Column<int>(type: "int", nullable: false),
                    IdJudge = table.Column<int>(type: "int", nullable: false),
                    JudgeId = table.Column<int>(type: "int", nullable: true),
                    CircleStatisticsId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticsDecisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticsDecisions_CaseYear_CaseYearId",
                        column: x => x.CaseYearId,
                        principalTable: "CaseYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StatisticsDecisions_CircleStatistics_CircleStatisticsId",
                        column: x => x.CircleStatisticsId,
                        principalTable: "CircleStatistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatisticsDecisions_CircleStatistics_IdCircleStatistics",
                        column: x => x.IdCircleStatistics,
                        principalTable: "CircleStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StatisticsDecisions_Decisions_IdDecision",
                        column: x => x.IdDecision,
                        principalTable: "Decisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StatisticsDecisions_Judges_JudgeId",
                        column: x => x.JudgeId,
                        principalTable: "Judges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatisticsDecisions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StatisticsDelayCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCircleStatistics = table.Column<int>(type: "int", nullable: false),
                    IdDelayCase = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    MonthDelay = table.Column<int>(type: "int", nullable: false),
                    YearDelay = table.Column<int>(type: "int", nullable: false),
                    CaseYearId = table.Column<int>(type: "int", nullable: false),
                    DelayCaseId = table.Column<int>(type: "int", nullable: true),
                    CircleStatisticsId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticsDelayCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticsDelayCases_CaseYear_CaseYearId",
                        column: x => x.CaseYearId,
                        principalTable: "CaseYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StatisticsDelayCases_CircleStatistics_CircleStatisticsId",
                        column: x => x.CircleStatisticsId,
                        principalTable: "CircleStatistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatisticsDelayCases_CircleStatistics_IdCircleStatistics",
                        column: x => x.IdCircleStatistics,
                        principalTable: "CircleStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StatisticsDelayCases_DelayCases_DelayCaseId",
                        column: x => x.DelayCaseId,
                        principalTable: "DelayCases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatisticsDelayCases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StatisticsInterCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCircleStatistics = table.Column<int>(type: "int", nullable: false),
                    IdInterCase = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CaseYearId = table.Column<int>(type: "int", nullable: false),
                    InterCaseId = table.Column<int>(type: "int", nullable: true),
                    CircleStatisticsId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticsInterCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatisticsInterCases_CaseYear_CaseYearId",
                        column: x => x.CaseYearId,
                        principalTable: "CaseYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StatisticsInterCases_CircleStatistics_CircleStatisticsId",
                        column: x => x.CircleStatisticsId,
                        principalTable: "CircleStatistics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatisticsInterCases_CircleStatistics_IdCircleStatistics",
                        column: x => x.IdCircleStatistics,
                        principalTable: "CircleStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StatisticsInterCases_InterCases_InterCaseId",
                        column: x => x.InterCaseId,
                        principalTable: "InterCases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StatisticsInterCases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "Enable", "FullName", "Password", "UserName" },
                values: new object[] { 1, 0, true, "مدير النظام", "ADMIN", "admin" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "Id", "Code", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "ADD_USER", "إضافة مستخدم", 1 },
                    { 2, "EDIT_USER", "تعديل مستخدم", 1 },
                    { 3, "DELETE_USER", "حذف مستخدم", 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Code", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "ADMIN", "مدير النظام", 1 },
                    { 2, "JUDGE", "قاضٍ", 1 }
                });

            migrationBuilder.InsertData(
                table: "RoleOperations",
                columns: new[] { "Id", "IdOperation", "IdRole", "OperationId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, 1 },
                    { 2, 2, 1, null, null, 1 },
                    { 3, 3, 1, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "IdRole", "RoleId", "UserCreatedId", "UserId", "UserId1" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_CircleDays_CircleId",
                table: "CircleDays",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_CircleDays_CircleTypeId",
                table: "CircleDays",
                column: "CircleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CircleJudges_CircleId",
                table: "CircleJudges",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_CircleJudges_IdCircle",
                table: "CircleJudges",
                column: "IdCircle");

            migrationBuilder.CreateIndex(
                name: "IX_CircleJudges_IdJudge_IdCircle_DateStart_DateEnd",
                table: "CircleJudges",
                columns: new[] { "IdJudge", "IdCircle", "DateStart", "DateEnd" },
                unique: true,
                filter: "[DateEnd] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CircleJudges_JudgeId",
                table: "CircleJudges",
                column: "JudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_CircleJudges_UserId",
                table: "CircleJudges",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Circles_Name",
                table: "Circles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Circles_UserId",
                table: "Circles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CircleStatistics_CircleDayId",
                table: "CircleStatistics",
                column: "CircleDayId");

            migrationBuilder.CreateIndex(
                name: "IX_CircleStatistics_UserId",
                table: "CircleStatistics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CircleTypes_UserId",
                table: "CircleTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DecisionCategories_UserId",
                table: "DecisionCategories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_DecisionCategoryId",
                table: "Decisions",
                column: "DecisionCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Decisions_UserId",
                table: "Decisions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DelayCases_UserId",
                table: "DelayCases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InterCases_InterCasesCategoryId",
                table: "InterCases",
                column: "InterCasesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InterCases_UserId",
                table: "InterCases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InterCasesCategories_UserId",
                table: "InterCasesCategories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Judges_Name",
                table: "Judges",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Judges_UserId",
                table: "Judges",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_Name",
                table: "Operations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operations_UserId",
                table: "Operations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperations_IdOperation",
                table: "RoleOperations",
                column: "IdOperation");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperations_IdRole_IdOperation",
                table: "RoleOperations",
                columns: new[] { "IdRole", "IdOperation" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperations_OperationId",
                table: "RoleOperations",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperations_RoleId",
                table: "RoleOperations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleOperations_UserId",
                table: "RoleOperations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDecisions_CaseYearId",
                table: "StatisticsDecisions",
                column: "CaseYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDecisions_CircleStatisticsId",
                table: "StatisticsDecisions",
                column: "CircleStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDecisions_IdCircleStatistics",
                table: "StatisticsDecisions",
                column: "IdCircleStatistics");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDecisions_IdDecision",
                table: "StatisticsDecisions",
                column: "IdDecision");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDecisions_JudgeId",
                table: "StatisticsDecisions",
                column: "JudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDecisions_UserId",
                table: "StatisticsDecisions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDelayCases_CaseYearId",
                table: "StatisticsDelayCases",
                column: "CaseYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDelayCases_CircleStatisticsId",
                table: "StatisticsDelayCases",
                column: "CircleStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDelayCases_DelayCaseId",
                table: "StatisticsDelayCases",
                column: "DelayCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDelayCases_IdCircleStatistics",
                table: "StatisticsDelayCases",
                column: "IdCircleStatistics");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsDelayCases_UserId",
                table: "StatisticsDelayCases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsInterCases_CaseYearId",
                table: "StatisticsInterCases",
                column: "CaseYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsInterCases_CircleStatisticsId",
                table: "StatisticsInterCases",
                column: "CircleStatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsInterCases_IdCircleStatistics",
                table: "StatisticsInterCases",
                column: "IdCircleStatistics");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsInterCases_InterCaseId",
                table: "StatisticsInterCases",
                column: "InterCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticsInterCases_UserId",
                table: "StatisticsInterCases",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupCourts_SuperCourtId",
                table: "SupCourts",
                column: "SuperCourtId");

            migrationBuilder.CreateIndex(
                name: "IX_SupCourts_UserId",
                table: "SupCourts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperCourts_UserId",
                table: "SuperCourts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCircles_CircleId",
                table: "UserCircles",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCircles_UserId",
                table: "UserCircles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_IdRole",
                table: "UserRoles",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId_IdRole",
                table: "UserRoles",
                columns: new[] { "UserId", "IdRole" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId1",
                table: "UserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FullName",
                table: "Users",
                column: "FullName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

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
                name: "CircleJudges");

            migrationBuilder.DropTable(
                name: "DelayCacesForMonths");

            migrationBuilder.DropTable(
                name: "RoleOperations");

            migrationBuilder.DropTable(
                name: "StatisticsDecisions");

            migrationBuilder.DropTable(
                name: "StatisticsDelayCases");

            migrationBuilder.DropTable(
                name: "StatisticsInterCases");

            migrationBuilder.DropTable(
                name: "UserCircles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserSupCourts");

            migrationBuilder.DropTable(
                name: "UserSuperCourts");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Decisions");

            migrationBuilder.DropTable(
                name: "Judges");

            migrationBuilder.DropTable(
                name: "DelayCases");

            migrationBuilder.DropTable(
                name: "CaseYear");

            migrationBuilder.DropTable(
                name: "CircleStatistics");

            migrationBuilder.DropTable(
                name: "InterCases");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SupCourts");

            migrationBuilder.DropTable(
                name: "DecisionCategories");

            migrationBuilder.DropTable(
                name: "CircleDays");

            migrationBuilder.DropTable(
                name: "InterCasesCategories");

            migrationBuilder.DropTable(
                name: "SuperCourts");

            migrationBuilder.DropTable(
                name: "CircleTypes");

            migrationBuilder.DropTable(
                name: "Circles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
