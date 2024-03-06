using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

namespace Aqua.Migrations
{
    /// <inheritdoc />
    public partial class AddingBankChekTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bankChek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChekNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ChekPrice = table.Column<int>(type: "int", nullable: false),
                    Assignment = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IssueDtaeSTR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDateSTR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankChek", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bankChek");
        }
    }
}
