using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityDoors.DataAccessLayer.Migrations
{
    public partial class AddFieldStatusInD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Doors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Doors");
        }
    }
}
