using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGo.Migrations
{
    public partial class OfferFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfferId",
                table: "Announcements",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_OfferId",
                table: "Announcements",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Offers_OfferId",
                table: "Announcements",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Offers_OfferId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_OfferId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Announcements");
        }
    }
}
