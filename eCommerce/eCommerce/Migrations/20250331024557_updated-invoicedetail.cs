using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eCommerce.Migrations
{
    /// <inheritdoc />
    public partial class updatedinvoicedetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 2,
                column: "InvoiceId",
                value: 1);

            migrationBuilder.InsertData(
                table: "InvoiceDetails",
                columns: new[] { "InvoiceDetailId", "InvoiceId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 3, 2, 3, 1 },
                    { 4, 2, 4, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "InvoiceDetails",
                keyColumn: "InvoiceDetailId",
                keyValue: 2,
                column: "InvoiceId",
                value: 2);
        }
    }
}
