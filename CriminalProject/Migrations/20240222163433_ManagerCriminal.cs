using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CriminalProject.Migrations
{
    /// <inheritdoc />
    public partial class ManagerCriminal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Managers",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Managers",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LocationIssued",
                table: "CriminalRecord",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IssuedBy",
                table: "CriminalRecord",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerNoForeign",
                table: "CriminalRecord",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CriminalRecord_ManagerNoForeign",
                table: "CriminalRecord",
                column: "ManagerNoForeign");

            migrationBuilder.AddForeignKey(
                name: "FK_CriminalRecord_Managers_ManagerNoForeign",
                table: "CriminalRecord",
                column: "ManagerNoForeign",
                principalTable: "Managers",
                principalColumn: "ManagerNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriminalRecord_Managers_ManagerNoForeign",
                table: "CriminalRecord");

            migrationBuilder.DropIndex(
                name: "IX_CriminalRecord_ManagerNoForeign",
                table: "CriminalRecord");

            migrationBuilder.DropColumn(
                name: "ManagerNoForeign",
                table: "CriminalRecord");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "LocationIssued",
                table: "CriminalRecord",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "IssuedBy",
                table: "CriminalRecord",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    CaseNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerNo = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Offence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sentence = table.Column<int>(type: "int", nullable: false),
                    SuspectID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuspectLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuspectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.CaseNo);
                    table.ForeignKey(
                        name: "FK_Case_Managers_ManagerNo",
                        column: x => x.ManagerNo,
                        principalTable: "Managers",
                        principalColumn: "ManagerNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Case_ManagerNo",
                table: "Case",
                column: "ManagerNo");
        }
    }
}
