using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityDoors.DataAccessLayer.Migrations
{
    public partial class ControlMigration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoorPassings_People_PersonId",
                table: "DoorPassings");

            migrationBuilder.DropIndex(
                name: "IX_DoorPassings_PersonId",
                table: "DoorPassings");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "DoorPassings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "DoorPassings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoorPassings_PersonId",
                table: "DoorPassings",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoorPassings_People_PersonId",
                table: "DoorPassings",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
