using Microsoft.EntityFrameworkCore.Migrations;

namespace WourkoutAPI.Migrations
{
    public partial class addExerciseCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseCategory_CategoryId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseCategory",
                table: "ExerciseCategory");

            migrationBuilder.RenameTable(
                name: "ExerciseCategory",
                newName: "ExerciseCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseCategory_Name",
                table: "ExerciseCategories",
                newName: "IX_ExerciseCategories_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseCategories",
                table: "ExerciseCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseCategories_CategoryId",
                table: "Exercises",
                column: "CategoryId",
                principalTable: "ExerciseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseCategories_CategoryId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseCategories",
                table: "ExerciseCategories");

            migrationBuilder.RenameTable(
                name: "ExerciseCategories",
                newName: "ExerciseCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseCategories_Name",
                table: "ExerciseCategory",
                newName: "IX_ExerciseCategory_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseCategory",
                table: "ExerciseCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseCategory_CategoryId",
                table: "Exercises",
                column: "CategoryId",
                principalTable: "ExerciseCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
