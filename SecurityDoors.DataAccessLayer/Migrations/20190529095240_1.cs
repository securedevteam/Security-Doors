using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityDoors.DataAccessLayer.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Doors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "DoorPassings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Doors");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "DoorPassings");
        }
    }
}
