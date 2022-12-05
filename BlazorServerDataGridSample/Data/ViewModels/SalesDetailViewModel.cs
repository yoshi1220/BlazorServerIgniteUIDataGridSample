using System.ComponentModel.DataAnnotations;

namespace BlazorServerDataGridSample.Data.ViewModels;

[CustomValidation(typeof(SalesDetailViewModel), "SalesDetailCheck")]
public class SalesDetailViewModel
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "伝票番号")]
    public int SlipNumber { get; set; }

    [Display(Name = "行番号")]
    public int RowNumber { get; set; }

    [Display(Name = "商品コード")]
    public string ItemCode { get; set; } = "";

    [Display(Name = "商品名")]
    public string ItemName { get; set; } = "";

    [Display(Name = "数量")]
    public decimal Quantity { get; set; }

    [Display(Name = "単価")]
    public decimal UnitPrice { get; set; }

    [Display(Name = "金額")]
    public decimal Amount { get; set; }

    [Display(Name = "消費税")]
    public decimal SalesTax { get; set; }

    public static ValidationResult? SalesDetailCheck(SalesDetailViewModel model, ValidationContext context)
    {
        if (model == null)
        {
            throw new NullReferenceException();
        }

        return ValidationResult.Success;
    }
}
