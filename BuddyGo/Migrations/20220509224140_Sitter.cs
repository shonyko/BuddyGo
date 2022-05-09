using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGo.Migrations
{
    public partial class Sitter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSitter",
                table: "Sitters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "Owners",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSitter",
                table: "Sitters");

            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "Owners");
        }
    }
}
