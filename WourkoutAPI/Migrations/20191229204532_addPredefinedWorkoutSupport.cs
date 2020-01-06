using Microsoft.EntityFrameworkCore.Migrations;

namespace WourkoutAPI.Migrations
{
    public partial class addPredefinedWorkoutSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPredefined",
                table: "Workouts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPredefined",
                table: "Workouts");
        }
    }
}
