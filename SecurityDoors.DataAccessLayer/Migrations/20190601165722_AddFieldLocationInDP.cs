using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityDoors.DataAccessLayer.Migrations
{
    public partial class AddFieldLocationInDP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Location",
                table: "DoorPassings",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "DoorPassings");
        }
    }
}
