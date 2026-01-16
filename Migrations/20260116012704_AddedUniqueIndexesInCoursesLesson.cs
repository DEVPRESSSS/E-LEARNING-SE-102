using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LEARNING_SE_102_PROJECT.Migrations
{
    /// <inheritdoc />
    public partial class AddedUniqueIndexesInCoursesLesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Lessons_Title",
                table: "Lessons",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Title",
                table: "Courses",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lessons_Title",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Title",
                table: "Courses");
        }
    }
}
