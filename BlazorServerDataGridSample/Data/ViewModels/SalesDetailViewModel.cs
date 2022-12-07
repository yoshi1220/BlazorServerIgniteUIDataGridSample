using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace BlazorServerDataGridSample.Data.ViewModels;


[CustomValidation(typeof(SalesDetailViewModel), "SalesDetailCheck")]
public class SalesDetailViewModel
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Display(Name = "伝票番号"), Range(1, 99999, ErrorMessage = "伝票番号は 1～99999 で指定してください")]
    public int SlipNumber { get; set; }

    [Display(Name = "行番号"), Range(1, int.MaxValue, ErrorMessage = "行番号は 1 以上を指定してください")]
    public int RowNumber { get; set; }

    [Display(Name = "商品コード"), Required(ErrorMessage = "商品コードを入力してください"), StringLength(10, ErrorMessage = "商品コードは 10 文字までです")]
    public string ItemCode { get; set; } = "";

    [Display(Name = "商品名"), Required(ErrorMessage = "商品名を入力してください"), StringLength(10, ErrorMessage = "商品名は 10 文字までです")]
    public string ItemName { get; set; } = "";

    [Display(Name = "数量"), Range(0, int.MaxValue, ErrorMessage = "数量は 0 以上を指定してください")]
    public decimal Quantity { get; set; }

    [Display(Name = "単価"), Range(0, int.MaxValue, ErrorMessage = "単価は 0 以上を指定してください")]
    public decimal UnitPrice { get; set; }


    [Display(Name = "金額")]
    public decimal Amount { get; set; }

    [Display(Name = "消費税")]
    public decimal SalesTax { get; set; }

    [Display(Name = "得意先情報1")]
    public string CustomerInfo1 { get; set; } = "";

    [Display(Name = "得意先情報2")]
    public string CustomerInfo2 { get; set; } = "";

    public static ValidationResult? SalesDetailCheck(SalesDetailViewModel model, ValidationContext context)
    {
        if (model == null)
        {
            throw new NullReferenceException();
        }

        return ValidationResult.Success;
    }

    private static readonly IMapper Mapper = new MapperConfiguration(cfg => cfg.CreateMap<SalesDetailViewModel, SalesDetailViewModel>()).CreateMapper();

    public SalesDetailViewModel Clone()
    {
        return Mapper.Map<SalesDetailViewModel>(this);
    }

}

