using Microsoft.EntityFrameworkCore.Migrations;

namespace assignment2.Data.Migrations
{
    public partial class DyllanFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coach",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Event_CoachId",
                table: "Event",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Coach_CoachId",
                table: "Event",
                column: "CoachId",
                principalTable: "Coach",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Coach_CoachId",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_CoachId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "Coach",
                table: "Event",
                nullable: true);
        }
    }
}
