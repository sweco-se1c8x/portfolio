using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioBackend.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competencies_Projects_ProjectId1",
                table: "Competencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competencies",
                table: "Competencies");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Competencies");

            migrationBuilder.RenameColumn(
                name: "ProjectId1",
                table: "Competencies",
                newName: "ProjectPk");

            migrationBuilder.RenameIndex(
                name: "IX_Competencies_ProjectId1",
                table: "Competencies",
                newName: "IX_Competencies_ProjectPk");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Pk",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Competencies",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Pk",
                table: "Competencies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Pk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competencies",
                table: "Competencies",
                column: "Pk");

            migrationBuilder.AddForeignKey(
                name: "FK_Competencies_Projects_ProjectPk",
                table: "Competencies",
                column: "ProjectPk",
                principalTable: "Projects",
                principalColumn: "Pk",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competencies_Projects_ProjectPk",
                table: "Competencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competencies",
                table: "Competencies");

            migrationBuilder.DropColumn(
                name: "Pk",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Pk",
                table: "Competencies");

            migrationBuilder.RenameColumn(
                name: "ProjectPk",
                table: "Competencies",
                newName: "ProjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_Competencies_ProjectPk",
                table: "Competencies",
                newName: "IX_Competencies_ProjectId1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Projects",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Competencies",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                table: "Competencies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competencies",
                table: "Competencies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Competencies_Projects_ProjectId1",
                table: "Competencies",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
