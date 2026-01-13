using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Competencies_ProjectPk",
                table: "Competencies");

            migrationBuilder.DropColumn(
                name: "Pk",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Pk",
                table: "Competencies");

            migrationBuilder.DropColumn(
                name: "ProjectPk",
                table: "Competencies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competencies",
                table: "Competencies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Competencies_ProjectId",
                table: "Competencies",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competencies_Projects_ProjectId",
                table: "Competencies",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competencies_Projects_ProjectId",
                table: "Competencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competencies",
                table: "Competencies");

            migrationBuilder.DropIndex(
                name: "IX_Competencies_ProjectId",
                table: "Competencies");

            migrationBuilder.AddColumn<int>(
                name: "Pk",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Pk",
                table: "Competencies",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProjectPk",
                table: "Competencies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Pk");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competencies",
                table: "Competencies",
                column: "Pk");

            migrationBuilder.CreateIndex(
                name: "IX_Competencies_ProjectPk",
                table: "Competencies",
                column: "ProjectPk");

            migrationBuilder.AddForeignKey(
                name: "FK_Competencies_Projects_ProjectPk",
                table: "Competencies",
                column: "ProjectPk",
                principalTable: "Projects",
                principalColumn: "Pk",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
