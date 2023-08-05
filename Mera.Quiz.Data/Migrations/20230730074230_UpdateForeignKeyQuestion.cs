using Microsoft.EntityFrameworkCore.Migrations;

namespace Mera.Quiz.Data.Migrations
{
    public partial class UpdateForeignKeyQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Answer_CorrectAnswerID",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswerID",
                table: "Question",
                newName: "correctanswer_id");

            migrationBuilder.RenameIndex(
                name: "IX_Question_CorrectAnswerID",
                table: "Question",
                newName: "IX_Question_correctanswer_id");

            migrationBuilder.AlterColumn<int>(
                name: "correctanswer_id",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Answer_correctanswer_id",
                table: "Question",
                column: "correctanswer_id",
                principalTable: "Answer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Answer_correctanswer_id",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "correctanswer_id",
                table: "Question",
                newName: "CorrectAnswerID");

            migrationBuilder.RenameIndex(
                name: "IX_Question_correctanswer_id",
                table: "Question",
                newName: "IX_Question_CorrectAnswerID");

            migrationBuilder.AlterColumn<int>(
                name: "CorrectAnswerID",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Answer_CorrectAnswerID",
                table: "Question",
                column: "CorrectAnswerID",
                principalTable: "Answer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
