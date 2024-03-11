using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aqua.Migrations
{
    /// <inheritdoc />
    public partial class EditeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "CustomerPhoneNumber",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "CustomerSubCode",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "DateOfWork",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "NextVisitDate",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "SearchDateOfWork",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "SearchNextVisitDate",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "InvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "SalesInvoice",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "THeExpert",
                table: "SalesInvoice",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "SearchDateInvoice",
                table: "Invoices",
                newName: "SearchNextVisitDate");

            migrationBuilder.RenameColumn(
                name: "DateOfSalesInvoice",
                table: "Invoices",
                newName: "NextVisitDate");

            migrationBuilder.AddColumn<int>(
                name: "FiVahed",
                table: "SalesInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "SalesInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TPRice",
                table: "SalesInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Invoices",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhoneNumber",
                table: "Invoices",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerSubCode",
                table: "Invoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfWork",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SearchDateOfWork",
                table: "Invoices",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceModel",
                table: "InvoiceDetails",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FiVahed",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TPRice",
                table: "InvoiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FiVahed",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "TPRice",
                table: "SalesInvoice");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerPhoneNumber",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerSubCode",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DateOfWork",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SearchDateOfWork",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DeviceModel",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "FiVahed",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "TPRice",
                table: "InvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "SalesInvoice",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "SalesInvoice",
                newName: "THeExpert");

            migrationBuilder.RenameColumn(
                name: "SearchNextVisitDate",
                table: "Invoices",
                newName: "SearchDateInvoice");

            migrationBuilder.RenameColumn(
                name: "NextVisitDate",
                table: "Invoices",
                newName: "DateOfSalesInvoice");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "SalesInvoice",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "SalesInvoice",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhoneNumber",
                table: "SalesInvoice",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerSubCode",
                table: "SalesInvoice",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfWork",
                table: "SalesInvoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NextVisitDate",
                table: "SalesInvoice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SearchDateOfWork",
                table: "SalesInvoice",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SearchNextVisitDate",
                table: "SalesInvoice",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "InvoiceDetails",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
