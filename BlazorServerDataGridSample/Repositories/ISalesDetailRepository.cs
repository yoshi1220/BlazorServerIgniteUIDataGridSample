using BlazorServerDataGridSample.Data.Models;

namespace BlazorServerDataGridSample.Repositories;

public interface ISalesDetailRepository : IDetailRepository<SalesDetail>
{
    ValueTask UpdateAllAsync(IEnumerable<SalesDetail> entities);
}
