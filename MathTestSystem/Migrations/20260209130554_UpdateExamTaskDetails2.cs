using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MathTestSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExamTaskDetails2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpectedResult",
                table: "MathTask",
                newName: "StudentAnwer");

            migrationBuilder.RenameColumn(
                name: "ActualResult",
                table: "MathTask",
                newName: "CorrectAnswer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentAnwer",
                table: "MathTask",
                newName: "ExpectedResult");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "MathTask",
                newName: "ActualResult");
        }
    }
}
