using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueBoard.Persistence.Migrations
{
    public partial class AddParticipantStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Participants",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Participants");
        }
    }
}
