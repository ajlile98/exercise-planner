using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkoutHub.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { "1", "Upper body pushing exercise targeting chest, shoulders, and triceps", "Push-ups", null },
                    { "2", "Lower body compound exercise targeting quads, hamstrings, and glutes", "Squats", null },
                    { "3", "Full body compound exercise targeting back, glutes, and hamstrings", "Deadlifts", null },
                    { "4", "Upper body pressing exercise targeting chest, shoulders, and triceps", "Bench Press", null },
                    { "5", "Upper body pulling exercise targeting back and biceps", "Pull-ups", null },
                    { "6", "Upper back and bicep exercise", "Rows", null },
                    { "7", "Core stability exercise", "Plank", null },
                    { "8", "Lower body exercise targeting quads, glutes, and hamstrings", "Lunges", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: "8");
        }
    }
}
