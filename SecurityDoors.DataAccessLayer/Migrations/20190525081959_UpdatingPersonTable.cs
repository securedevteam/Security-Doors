using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityDoors.DataAccessLayer.Migrations
{
    public partial class UpdatingPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cards_CardId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CardId",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "People",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_People_CardId",
                table: "People",
                column: "CardId",
                unique: true,
                filter: "[CardId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cards_CardId",
                table: "People",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cards_CardId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_CardId",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "People",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CardId",
                table: "People",
                column: "CardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cards_CardId",
                table: "People",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
