using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalHealthTracker.Data.Migrations
{
    public partial class addmentalactivitytableswithseedingandrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mental_Activity_Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mental_Activity_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mental_Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    dayOfWeek = table.Column<int>(nullable: false),
                    Mental_Activity_TypeId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mental_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mental_Activities_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mental_Activities_Mental_Activity_Types_Mental_Activity_TypeId",
                        column: x => x.Mental_Activity_TypeId,
                        principalTable: "Mental_Activity_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Mental_Activity_Types",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Crossword" });

            migrationBuilder.InsertData(
                table: "Mental_Activity_Types",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Sudoku" });

            migrationBuilder.InsertData(
                table: "Mental_Activity_Types",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "Reading" });

            migrationBuilder.CreateIndex(
                name: "IX_Mental_Activities_AppUserId",
                table: "Mental_Activities",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mental_Activities_Mental_Activity_TypeId",
                table: "Mental_Activities",
                column: "Mental_Activity_TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mental_Activities");

            migrationBuilder.DropTable(
                name: "Mental_Activity_Types");
        }
    }
}
