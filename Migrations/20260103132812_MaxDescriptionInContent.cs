using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LEARNING_SE_102_PROJECT.Migrations
{
    /// <inheritdoc />
    public partial class MaxDescriptionInContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lessons_LessonId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LessonId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LessonId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Contents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LessonId",
                table: "Courses",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lessons_LessonId",
                table: "Courses",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId");
        }
    }
}
