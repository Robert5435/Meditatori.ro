using Microsoft.EntityFrameworkCore.Migrations;

namespace BeMyTeacher.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Califications_CalificationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CalificationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Califications_CalificationId",
                table: "AspNetUsers",
                column: "CalificationId",
                principalTable: "Califications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Califications_CalificationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CalificationId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Califications_CalificationId",
                table: "AspNetUsers",
                column: "CalificationId",
                principalTable: "Califications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
