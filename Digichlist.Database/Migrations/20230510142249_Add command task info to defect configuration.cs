using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digichlist.Database.Migrations
{
    public partial class Addcommandtaskinfotodefectconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandTasks_Defects_DefectId",
                table: "CommandTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandTasks_Defects_DefectId",
                table: "CommandTasks",
                column: "DefectId",
                principalTable: "Defects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandTasks_Defects_DefectId",
                table: "CommandTasks");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandTasks_Defects_DefectId",
                table: "CommandTasks",
                column: "DefectId",
                principalTable: "Defects",
                principalColumn: "Id");
        }
    }
}
