using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aqua.Migrations
{
    /// <inheritdoc />
    public partial class AddTheAssestTableInDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssestName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AssestPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AssestType = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AssestDateOfBuye = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assest", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assest");
        }
    }
}
