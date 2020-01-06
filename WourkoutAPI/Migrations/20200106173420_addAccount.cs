using Microsoft.EntityFrameworkCore.Migrations;

namespace WourkoutAPI.Migrations
{
    public partial class addAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "ExerciseWorkout",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "ExerciseWorkout");
        }
    }
}
