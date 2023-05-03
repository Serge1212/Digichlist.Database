using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digichlist.Database.Migrations
{
    public partial class AddCommandNamecolumntoCommandTaskInfotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandTasksInfo_Defects_DefectId",
                table: "CommandTasksInfo");

            migrationBuilder.AlterColumn<int>(
                name: "DefectId",
                table: "CommandTasksInfo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CommandName",
                table: "CommandTasksInfo",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandTasksInfo_Defects_DefectId",
                table: "CommandTasksInfo",
                column: "DefectId",
                principalTable: "Defects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandTasksInfo_Defects_DefectId",
                table: "CommandTasksInfo");

            migrationBuilder.DropColumn(
                name: "CommandName",
                table: "CommandTasksInfo");

            migrationBuilder.AlterColumn<int>(
                name: "DefectId",
                table: "CommandTasksInfo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandTasksInfo_Defects_DefectId",
                table: "CommandTasksInfo",
                column: "DefectId",
                principalTable: "Defects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
