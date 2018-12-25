using Microsoft.EntityFrameworkCore.Migrations;

namespace CAP.BS19.API.Migrations
{
    public partial class AddRelationsInUserInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "UserInformation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_CompanyId",
                table: "UserInformation",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_OfficeId",
                table: "UserInformation",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInformation_UserRoleId",
                table: "UserInformation",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInformation_Companies_CompanyId",
                table: "UserInformation",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInformation_Offices_OfficeId",
                table: "UserInformation",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "OfficeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInformation_UserRoles_UserRoleId",
                table: "UserInformation",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInformation_Companies_CompanyId",
                table: "UserInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInformation_Offices_OfficeId",
                table: "UserInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInformation_UserRoles_UserRoleId",
                table: "UserInformation");

            migrationBuilder.DropIndex(
                name: "IX_UserInformation_CompanyId",
                table: "UserInformation");

            migrationBuilder.DropIndex(
                name: "IX_UserInformation_OfficeId",
                table: "UserInformation");

            migrationBuilder.DropIndex(
                name: "IX_UserInformation_UserRoleId",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "UserInformation");
        }
    }
}
