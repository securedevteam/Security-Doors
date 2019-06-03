using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityDoors.DataAccessLayer.Migrations
{
    public partial class AddFieldsLevelLocationInC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Location",
                table: "Cards",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Cards");
        }
    }
}
