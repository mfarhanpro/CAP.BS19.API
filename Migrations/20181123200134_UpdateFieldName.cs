using Microsoft.EntityFrameworkCore.Migrations;

namespace CAP.BS19.API.Migrations
{
    public partial class UpdateFieldName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserInformation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserInformation",
                nullable: true);
        }
    }
}
