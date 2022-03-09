using Microsoft.EntityFrameworkCore.Migrations;

namespace Mera.Quiz.Data.Migrations
{
    public partial class changingTestScoreFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestScore_Test_TestNameFK",
                table: "TestScore");

            migrationBuilder.DropForeignKey(
                name: "FK_TestScore_User_UserNameFK",
                table: "TestScore");

            migrationBuilder.DropIndex(
                name: "IX_TestScore_TestNameFK",
                table: "TestScore");

            migrationBuilder.DropIndex(
                name: "IX_TestScore_UserNameFK",
                table: "TestScore");

            migrationBuilder.DropColumn(
                name: "TestNameFK",
                table: "TestScore");

            migrationBuilder.DropColumn(
                name: "UserNameFK",
                table: "TestScore");

            migrationBuilder.AddColumn<int>(
                name: "TestNameID",
                table: "TestScore",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserNameID",
                table: "TestScore",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestScore_TestNameID",
                table: "TestScore",
                column: "TestNameID");

            migrationBuilder.CreateIndex(
                name: "IX_TestScore_UserNameID",
                table: "TestScore",
                column: "UserNameID");

            migrationBuilder.AddForeignKey(
                name: "FK_TestScore_Test_TestNameID",
                table: "TestScore",
                column: "TestNameID",
                principalTable: "Test",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestScore_User_UserNameID",
                table: "TestScore",
                column: "UserNameID",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestScore_Test_TestNameID",
                table: "TestScore");

            migrationBuilder.DropForeignKey(
                name: "FK_TestScore_User_UserNameID",
                table: "TestScore");

            migrationBuilder.DropIndex(
                name: "IX_TestScore_TestNameID",
                table: "TestScore");

            migrationBuilder.DropIndex(
                name: "IX_TestScore_UserNameID",
                table: "TestScore");

            migrationBuilder.DropColumn(
                name: "TestNameID",
                table: "TestScore");

            migrationBuilder.DropColumn(
                name: "UserNameID",
                table: "TestScore");

            migrationBuilder.AddColumn<int>(
                name: "TestNameFK",
                table: "TestScore",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserNameFK",
                table: "TestScore",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestScore_TestNameFK",
                table: "TestScore",
                column: "TestNameFK");

            migrationBuilder.CreateIndex(
                name: "IX_TestScore_UserNameFK",
                table: "TestScore",
                column: "UserNameFK");

            migrationBuilder.AddForeignKey(
                name: "FK_TestScore_Test_TestNameFK",
                table: "TestScore",
                column: "TestNameFK",
                principalTable: "Test",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestScore_User_UserNameFK",
                table: "TestScore",
                column: "UserNameFK",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
