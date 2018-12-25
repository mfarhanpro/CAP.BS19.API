using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CAP.BS19.API.Migrations
{
    public partial class ChangePasswordPolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserInformation");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "UserInformation",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "UserInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserInformation");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "UserInformation");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserInformation",
                nullable: true);
        }
    }
}
