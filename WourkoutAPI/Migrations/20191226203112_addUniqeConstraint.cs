using Microsoft.EntityFrameworkCore.Migrations;

namespace WourkoutAPI.Migrations
{
    public partial class addUniqeConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WorkoutTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutTypes_Name",
                table: "WorkoutTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDifficulties_Name",
                table: "WorkoutDifficulties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_Name",
                table: "Exercises",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCategory_Name",
                table: "ExerciseCategory",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkoutTypes_Name",
                table: "WorkoutTypes");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutDifficulties_Name",
                table: "WorkoutDifficulties");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_Name",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseCategory_Name",
                table: "ExerciseCategory");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WorkoutTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
