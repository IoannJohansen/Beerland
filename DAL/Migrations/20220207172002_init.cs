using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BeerMarks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerMarks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionStatictics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Target = table.Column<double>(type: "REAL", nullable: false),
                    Produced = table.Column<double>(type: "REAL", nullable: false),
                    BeerMarkId = table.Column<long>(type: "INTEGER", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionStatictics");

            migrationBuilder.DropTable(
                name: "BeerMarks");
        }
    }
}
