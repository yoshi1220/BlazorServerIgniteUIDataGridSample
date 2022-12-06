using BlazorServerDataGridSample.Data.Models;
using BlazorServerDataGridSample.Data.ViewModels;

namespace BlazorServerDataGridSample.Services;

interface ISalesDetailService : IDetailService<SalesDetail>
{
    IList<SalesDetailViewModel> GetDispAll();
}
