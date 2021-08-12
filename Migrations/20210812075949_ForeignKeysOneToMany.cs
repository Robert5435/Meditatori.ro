using Microsoft.EntityFrameworkCore.Migrations;

namespace Meditatori.ro2.Migrations
{
    public partial class ForeignKeysOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ads_EducationLevelId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_LocationId",
                table: "Ads");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_EducationLevelId",
                table: "Ads",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_LocationId",
                table: "Ads",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ads_EducationLevelId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_LocationId",
                table: "Ads");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_EducationLevelId",
                table: "Ads",
                column: "EducationLevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ads_LocationId",
                table: "Ads",
                column: "LocationId",
                unique: true);
        }
    }
}
