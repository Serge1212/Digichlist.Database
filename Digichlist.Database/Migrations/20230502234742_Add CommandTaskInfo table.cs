using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digichlist.Database.Migrations
{
    public partial class AddCommandTaskInfotable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandTasksInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    DefectId = table.Column<int?>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandTasksInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommandTasksInfo_Defects_DefectId",
                        column: x => x.DefectId,
                        principalTable: "Defects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandTasksInfo_DefectId",
                table: "CommandTasksInfo",
                column: "DefectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandTasksInfo");
        }
    }
}
