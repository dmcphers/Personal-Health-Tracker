using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalHealthTracker.Data.Migrations
{
    public partial class addnutritiontableswithseedingandrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nutrition_Type",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrition_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nutrition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    Calories = table.Column<int>(nullable: false),
                    dayOfWeek = table.Column<int>(nullable: false),
                    Nutrition_TypeId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nutrition_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nutrition_Nutrition_Type_Nutrition_TypeId",
                        column: x => x.Nutrition_TypeId,
                        principalTable: "Nutrition_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Nutrition_Type",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Steak" },
                    { 2, "Bread" },
                    { 3, "Apple" },
                    { 4, "Milk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nutrition_AppUserId",
                table: "Nutrition",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutrition_Nutrition_TypeId",
                table: "Nutrition",
                column: "Nutrition_TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nutrition");

            migrationBuilder.DropTable(
                name: "Nutrition_Type");
        }
    }
}
