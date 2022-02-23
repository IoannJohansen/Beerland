using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class addConstraintToStateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionStatictics");

            migrationBuilder.CreateTable(
                name: "ProductionUnits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Target = table.Column<double>(type: "REAL", nullable: false),
                    Produced = table.Column<double>(type: "REAL", nullable: false),
                    BeerMarkId = table.Column<long>(type: "INTEGER", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionUnits", x => x.Id);
                    table.CheckConstraint("CHECK_ProductionUnit_State", "State in (0,1)");
                    table.ForeignKey(
                        name: "FK_ProductionUnits_BeerMarks_BeerMarkId",
                        column: x => x.BeerMarkId,
                        principalTable: "BeerMarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionUnits_BeerMarkId",
                table: "ProductionUnits",
                column: "BeerMarkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionUnits");

            migrationBuilder.CreateTable(
                name: "ProductionStatictics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeerMarkId = table.Column<long>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Produced = table.Column<double>(type: "REAL", nullable: false),
                    Target = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionStatictics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionStatictics_BeerMarks_BeerMarkId",
                        column: x => x.BeerMarkId,
                        principalTable: "BeerMarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductionStatictics_BeerMarkId",
                table: "ProductionStatictics",
                column: "BeerMarkId");
        }
    }
}
