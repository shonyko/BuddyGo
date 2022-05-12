using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGo.Migrations
{
    public partial class OfferFKs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Offers_OfferId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_OfferId",
                table: "Announcements");

            migrationBuilder.AddColumn<string>(
                name: "AnnouncementId",
                table: "Offers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SitterId",
                table: "Offers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "OfferId",
                table: "Announcements",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OfferId1",
                table: "Announcements",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_OfferId1",
                table: "Announcements",
                column: "OfferId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Offers_OfferId1",
                table: "Announcements",
                column: "OfferId1",
                principalTable: "Offers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Offers_OfferId1",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_OfferId1",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "SitterId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferId1",
                table: "Announcements");

            migrationBuilder.AlterColumn<string>(
                name: "OfferId",
                table: "Announcements",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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
    }
}
