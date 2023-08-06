using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mera.Quiz.Data.Migrations
{
    public partial class UserAnswersAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTaken",
                table: "TestScore",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionFK = table.Column<int>(type: "int", nullable: false),
                    ChosenAnswerFK = table.Column<int>(type: "int", nullable: false),
                    TestScoreID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Answer_ChosenAnswerFK",
                        column: x => x.ChosenAnswerFK,
                        principalTable: "Answer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserAnswers_Question_QuestionFK",
                        column: x => x.QuestionFK,
                        principalTable: "Question",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserAnswers_TestScore_TestScoreID",
                        column: x => x.TestScoreID,
                        principalTable: "TestScore",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_ChosenAnswerFK",
                table: "UserAnswers",
                column: "ChosenAnswerFK");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuestionFK",
                table: "UserAnswers",
                column: "QuestionFK");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_TestScoreID",
                table: "UserAnswers",
                column: "TestScoreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "DateTaken",
                table: "TestScore");
        }
    }
}
