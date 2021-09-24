using Microsoft.EntityFrameworkCore.Migrations;

namespace BeMyTeacher.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdViewModels",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityOnline = table.Column<bool>(type: "bit", nullable: false),
                    AvailabilityHome = table.Column<bool>(type: "bit", nullable: false),
                    AvailabilityStudentHome = table.Column<bool>(type: "bit", nullable: false),
                    PricePerSession = table.Column<int>(type: "int", nullable: false),
                    SessionLenghtinMinutes = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    EducationLevelId = table.Column<int>(type: "int", nullable: false),
                    CalificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdViewModels");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Subjects");
        }
    }
}
