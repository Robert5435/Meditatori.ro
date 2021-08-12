using Microsoft.EntityFrameworkCore.Migrations;

namespace Meditatori.ro2.Migrations
{
    public partial class ForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ads_SubjectId",
                table: "Ads");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_SubjectId",
                table: "Ads",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ads_SubjectId",
                table: "Ads");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_SubjectId",
                table: "Ads",
                column: "SubjectId",
                unique: true);
        }
    }
}
