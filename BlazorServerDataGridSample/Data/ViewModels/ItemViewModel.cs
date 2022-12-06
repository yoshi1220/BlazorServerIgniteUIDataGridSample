using System.ComponentModel.DataAnnotations;

namespace BlazorServerDataGridSample.Data.ViewModels;

public class ItemViewModel
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "商品コード")]
    public string ItemCode { get; set; } = "";

    [Display(Name = "商品名")]
    public string ItemName { get; set; } = "";

    [Display(Name = "単価")]
    public decimal UnitPrice { get; set; }
}
