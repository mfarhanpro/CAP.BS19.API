using Microsoft.EntityFrameworkCore.Migrations;

namespace CAP.BS19.API.Migrations
{
    public partial class ChangeIsActiveNIsDeletedDatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "UserInformation",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UserInformation",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsDeleted",
                table: "UserInformation",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "IsActive",
                table: "UserInformation",
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
