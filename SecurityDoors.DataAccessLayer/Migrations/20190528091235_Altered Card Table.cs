using Microsoft.EntityFrameworkCore.Migrations;

namespace SecurityDoors.DataAccessLayer.Migrations
{
    public partial class AlteredCardTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Passport",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Doors",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "SecondName",
                table: "People",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Passport",
                table: "People",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "People",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "People",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doors",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Doors",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
