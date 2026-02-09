using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathTestSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExamTaskDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "ExamTaskResults",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Formula",
                table: "ExamTaskResults",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentAnswer",
                table: "ExamTaskResults",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "ExamTaskResults");

            migrationBuilder.DropColumn(
                name: "Formula",
                table: "ExamTaskResults");

            migrationBuilder.DropColumn(
                name: "StudentAnswer",
                table: "ExamTaskResults");
        }
    }
}
