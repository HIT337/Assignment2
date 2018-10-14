using Microsoft.EntityFrameworkCore.Migrations;

namespace assignment2.Data.Migrations
{
    public partial class DyllanFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Coach_CoachId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Event_EventId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Member_MemberId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_EventId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_MemberId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Event_CoachId",
                table: "Event");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Schedule_EventId",
                table: "Schedule",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_MemberId",
                table: "Schedule",
                column: "MemberId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Event_EventId",
                table: "Schedule",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Member_MemberId",
                table: "Schedule",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
