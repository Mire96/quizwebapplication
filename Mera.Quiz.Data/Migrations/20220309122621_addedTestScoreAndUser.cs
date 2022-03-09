using Microsoft.EntityFrameworkCore.Migrations;

namespace Mera.Quiz.Data.Migrations
{
    public partial class addedTestScoreAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(20)", nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TestScore",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestNameFK = table.Column<int>(type: "int", nullable: false),
                    UserNameFK = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestScore", x => x.id);
                    table.ForeignKey(
                        name: "FK_TestScore_Test_TestNameFK",
                        column: x => x.TestNameFK,
                        principalTable: "Test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestScore_User_UserNameFK",
                        column: x => x.UserNameFK,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestScore_TestNameFK",
                table: "TestScore",
                column: "TestNameFK");

            migrationBuilder.CreateIndex(
                name: "IX_TestScore_UserNameFK",
                table: "TestScore",
                column: "UserNameFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestScore");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
