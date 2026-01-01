using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oid85.Health.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "GlucoseEntities",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    BeforeMorningFood = table.Column<double>(type: "double precision", nullable: true),
                    AfterMorningFood = table.Column<double>(type: "double precision", nullable: true),
                    BeforeTraining = table.Column<double>(type: "double precision", nullable: true),
                    AfterTraining = table.Column<double>(type: "double precision", nullable: true),
                    BeforeEveningFood = table.Column<double>(type: "double precision", nullable: true),
                    BeforeNight = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlucoseEntities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PressureEntities",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Sys = table.Column<int>(type: "integer", nullable: false),
                    Dia = table.Column<int>(type: "integer", nullable: false),
                    Pulse = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressureEntities", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlucoseEntities",
                schema: "public");

            migrationBuilder.DropTable(
                name: "PressureEntities",
                schema: "public");
        }
    }
}
