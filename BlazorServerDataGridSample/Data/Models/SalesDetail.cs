using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerDataGridSample.Data.Models;

/// <summary>
/// 売上明細モデル
/// </summary>
[Table("SalesDetails")]
public class SalesDetail
{
    [Key]
    public int Id { get; set; }

    public int SlipNumber { get; set; }

    public int RowNumber { get; set; }

    public string ItemCode { get; set; } = "";

    public string ItemName { get; set; } = "";

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Amount { get; set; }

    public decimal SalesTax { get; set; }

    public string CustomerInfo1 { get; set; } = "";

    public string CustomerInfo2 { get; set; } = "";

    [Timestamp]
    public byte[]? TimeStamp { get; set; }
}
