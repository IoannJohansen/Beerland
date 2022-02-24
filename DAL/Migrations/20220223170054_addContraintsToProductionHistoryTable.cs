using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class addContraintsToProductionHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeerMark",
                table: "ProductionHistories");

            migrationBuilder.AddColumn<long>(
                name: "BeerMarkId",
                table: "ProductionHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionHistories_BeerMarkId",
                table: "ProductionHistories",
                column: "BeerMarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionHistories_BeerMarks_BeerMarkId",
                table: "ProductionHistories",
                column: "BeerMarkId",
                principalTable: "BeerMarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionHistories_BeerMarks_BeerMarkId",
                table: "ProductionHistories");

            migrationBuilder.DropIndex(
                name: "IX_ProductionHistories_BeerMarkId",
                table: "ProductionHistories");

            migrationBuilder.DropColumn(
                name: "BeerMarkId",
                table: "ProductionHistories");

            migrationBuilder.AddColumn<string>(
                name: "BeerMark",
                table: "ProductionHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
