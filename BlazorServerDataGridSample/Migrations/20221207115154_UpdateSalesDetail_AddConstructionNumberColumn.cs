using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerDataGridSample.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSalesDetailAddConstructionNumberColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConstructionNumber1",
                table: "SalesDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConstructionNumber2",
                table: "SalesDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "SalesDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConstructionNumber1", "ConstructionNumber2" },
                values: new object[] { "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConstructionNumber1",
                table: "SalesDetails");

            migrationBuilder.DropColumn(
                name: "ConstructionNumber2",
                table: "SalesDetails");
        }
    }
}
