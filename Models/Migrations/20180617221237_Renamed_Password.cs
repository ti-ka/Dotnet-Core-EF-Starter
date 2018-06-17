using Microsoft.EntityFrameworkCore.Migrations;

namespace Models.Migrations
{
    public partial class Renamed_Password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pasword",
                table: "Users",
                newName: "Password");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Pasword");
        }
    }
}
