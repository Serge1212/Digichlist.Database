using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digichlist.Database.Migrations
{
    public partial class removeexcessassigneddefect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Defects_Users_UserId",
                table: "Defects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AssignedDefects");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Defects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                table: "Defects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Defects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Defects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusChangedAt",
                table: "Defects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Defects_Users_UserId",
                table: "Defects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Defects_Users_UserId",
                table: "Defects");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClosedAt",
                table: "Defects");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Defects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Defects");

            migrationBuilder.DropColumn(
                name: "StatusChangedAt",
                table: "Defects");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Defects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AssignedDefects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ClosedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusChangedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedDefects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedDefects_Defects_DefectId",
                        column: x => x.DefectId,
                        principalTable: "Defects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedDefects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedDefects_DefectId",
                table: "AssignedDefects",
                column: "DefectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignedDefects_UserId",
                table: "AssignedDefects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Defects_Users_UserId",
                table: "Defects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
