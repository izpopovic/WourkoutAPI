using Microsoft.EntityFrameworkCore.Migrations;

namespace WourkoutAPI.Migrations
{
    public partial class realWorkoutDayFinish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutDay",
                table: "ExerciseWorkout");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutDay",
                table: "Workouts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutDay",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutDay",
                table: "ExerciseWorkout",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
