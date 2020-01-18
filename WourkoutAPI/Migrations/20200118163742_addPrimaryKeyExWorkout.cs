using Microsoft.EntityFrameworkCore.Migrations;

namespace WourkoutAPI.Migrations
{
    public partial class addPrimaryKeyExWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseCategory_CategoryId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseWorkout",
                table: "ExerciseWorkout");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExerciseWorkout",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Exercises",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseWorkout",
                table: "ExerciseWorkout",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkout_ExerciseId",
                table: "ExerciseWorkout",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseCategory_CategoryId",
                table: "Exercises",
                column: "CategoryId",
                principalTable: "ExerciseCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseCategory_CategoryId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseWorkout",
                table: "ExerciseWorkout");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseWorkout_ExerciseId",
                table: "ExerciseWorkout");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExerciseWorkout");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Exercises",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseWorkout",
                table: "ExerciseWorkout",
                columns: new[] { "ExerciseId", "WorkoutId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseCategory_CategoryId",
                table: "Exercises",
                column: "CategoryId",
                principalTable: "ExerciseCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
