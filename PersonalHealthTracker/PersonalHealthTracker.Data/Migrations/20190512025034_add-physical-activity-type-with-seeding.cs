using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalHealthTracker.Data.Migrations
{
    public partial class addphysicalactivitytypewithseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Physical_Activity_Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Physical_Activity_Types", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Physical_Activity_Types",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Jogging" });

            migrationBuilder.InsertData(
                table: "Physical_Activity_Types",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Walking" });

            migrationBuilder.InsertData(
                table: "Physical_Activity_Types",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "Swimming" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Physical_Activity_Types");
        }
    }
}
