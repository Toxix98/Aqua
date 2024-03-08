using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aqua.Migrations
{
    /// <inheritdoc />
    public partial class Edite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "SearchDatePurchaseInvoice",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "PurchaseInvoice");

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "PurchaseInvoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FiVahed",
                table: "PurchaseInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TPRice",
                table: "PurchaseInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "FiVahed",
                table: "PurchaseInvoice");

            migrationBuilder.DropColumn(
                name: "TPRice",
                table: "PurchaseInvoice");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfPurchase",
                table: "PurchaseInvoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "PurchaseInvoice",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "PurchaseInvoice",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SearchDatePurchaseInvoice",
                table: "PurchaseInvoice",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "PurchaseInvoice",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
