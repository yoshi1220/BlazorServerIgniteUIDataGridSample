using BlazorServerDataGridSample.Data.Models;

namespace BlazorServerDataGridSample.Repositories;

public interface ISalesDetailRepository : IDetailRepository<SalesDetail>
{
    void UpdateAll(IList<SalesDetail> entities);
}
