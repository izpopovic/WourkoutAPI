using Microsoft.EntityFrameworkCore.Migrations;

namespace WourkoutAPI.Migrations
{
    public partial class finalWorkoutDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutDay",
                table: "Workouts");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutDay",
                table: "ExerciseWorkout",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutDay",
                table: "ExerciseWorkout");

            migrationBuilder.AddColumn<int>(
                name: "WorkoutDay",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
