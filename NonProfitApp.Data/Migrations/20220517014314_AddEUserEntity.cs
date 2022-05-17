using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NonProfitApp.Data.Migrations
{
    public partial class AddEUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventEntityEventId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventEntityEventId",
                table: "Events",
                column: "EventEntityEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Events_EventEntityEventId",
                table: "Events",
                column: "EventEntityEventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Events_EventEntityEventId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventEntityEventId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventEntityEventId",
                table: "Events");
        }
    }
}
