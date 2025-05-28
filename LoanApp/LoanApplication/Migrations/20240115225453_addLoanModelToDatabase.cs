using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanApplication.Migrations
{
    public partial class addLoanModelToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrossSalary = table.Column<float>(type: "real", nullable: false),
                    CreditScore = table.Column<float>(type: "real", nullable: false),
                    PriceOfProperty = table.Column<float>(type: "real", nullable: false),
                    LoanStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximumInstalment = table.Column<float>(type: "real", nullable: false),
                    LoanGranted = table.Column<float>(type: "real", nullable: false),
                    DepositeRequired = table.Column<float>(type: "real", nullable: false),
                    MonthlyInstalment = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
