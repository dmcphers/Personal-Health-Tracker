using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalHealthTracker.Data.Migrations
{
    public partial class addphysicalActivityphysicalActivityTyperelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Physical_Activity_TypeId",
                table: "Physical_Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Physical_Activities_Physical_Activity_TypeId",
                table: "Physical_Activities",
                column: "Physical_Activity_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Physical_Activities_Physical_Activity_Types_Physical_Activity_TypeId",
                table: "Physical_Activities",
                column: "Physical_Activity_TypeId",
                principalTable: "Physical_Activity_Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Physical_Activities_Physical_Activity_Types_Physical_Activity_TypeId",
                table: "Physical_Activities");

            migrationBuilder.DropIndex(
                name: "IX_Physical_Activities_Physical_Activity_TypeId",
                table: "Physical_Activities");

            migrationBuilder.DropColumn(
                name: "Physical_Activity_TypeId",
                table: "Physical_Activities");
        }
    }
}
