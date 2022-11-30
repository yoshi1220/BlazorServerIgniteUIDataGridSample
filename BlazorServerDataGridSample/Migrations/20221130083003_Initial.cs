using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerDataGridSample.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlipNumber = table.Column<int>(type: "int", nullable: false),
                    RowNumber = table.Column<int>(type: "int", nullable: false),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SalesDetails",
                columns: new[] { "Id", "Amount", "ItemCode", "ItemName", "Quantity", "RowNumber", "SalesTax", "SlipNumber", "UnitPrice" },
                values: new object[] { 1, 990m, "S001", "商品1", 3m, 1, 99m, 10001, 330m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetails");
        }
    }
}
