using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerDataGridSample.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSalesDetailAddCustomerInfo1and2Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerInfo1",
                table: "SalesDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerInfo2",
                table: "SalesDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SalesDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomerInfo1", "CustomerInfo2" },
                values: new object[] { "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerInfo1",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "CustomerInfo2",
                table: "SalesDetails");
        }
    }
}
