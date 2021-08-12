using Microsoft.EntityFrameworkCore.Migrations;

namespace Meditatori.ro2.Migrations
{
    public partial class CalificationForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ads_CalificationId",
                table: "Ads");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CalificationId",
                table: "Ads",
                column: "CalificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ads_CalificationId",
                table: "Ads");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CalificationId",
                table: "Ads",
                column: "CalificationId",
                unique: true);
        }
    }
}
