using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityDoors.DataAccessLayer.Migrations
{
    public partial class ControlMigration_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoorPassings_People_PersonId",
                table: "DoorPassings");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "DoorPassings",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "DoorPassings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DoorPassings_CardId",
                table: "DoorPassings",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoorPassings_Cards_CardId",
                table: "DoorPassings",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoorPassings_People_PersonId",
                table: "DoorPassings",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoorPassings_Cards_CardId",
                table: "DoorPassings");

            migrationBuilder.DropForeignKey(
                name: "FK_DoorPassings_People_PersonId",
                table: "DoorPassings");

            migrationBuilder.DropIndex(
                name: "IX_DoorPassings_CardId",
                table: "DoorPassings");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "DoorPassings");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "DoorPassings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DoorPassings_People_PersonId",
                table: "DoorPassings",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
