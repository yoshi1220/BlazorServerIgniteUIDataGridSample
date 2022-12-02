using BlazorServerDataGridSample.Data.Models;
using BlazorServerDataGridSample.Data.ViewModels;
using BlazorServerDataGridSample.Services;

namespace BlazorServerDataGridSample.Services
{
    interface IItemService : IMasterService<Item>
    {
        IList<ItemViewModel> GetDispAll();
    }
}
