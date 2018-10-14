using Microsoft.EntityFrameworkCore.Migrations;

namespace assignment2.Data.Migrations
{
    public partial class DyllanFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Coach_AllocatedEventCoachId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Coach_AllocatedMemberCoachId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_AllocatedEventCoachId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_AllocatedMemberCoachId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "AllocatedEventCoachId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "AllocatedMemberCoachId",
                table: "Schedule");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_EventId",
                table: "Schedule",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_MemberId",
                table: "Schedule",
                column: "MemberId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "AllocatedEventCoachId",
                table: "Schedule",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AllocatedMemberCoachId",
                table: "Schedule",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_AllocatedEventCoachId",
                table: "Schedule",
                column: "AllocatedEventCoachId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_AllocatedMemberCoachId",
                table: "Schedule",
                column: "AllocatedMemberCoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Coach_AllocatedEventCoachId",
                table: "Schedule",
                column: "AllocatedEventCoachId",
                principalTable: "Coach",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Coach_AllocatedMemberCoachId",
                table: "Schedule",
                column: "AllocatedMemberCoachId",
                principalTable: "Coach",
                principalColumn: "CoachId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
