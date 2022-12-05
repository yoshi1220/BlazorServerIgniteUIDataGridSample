using BlazorServerDataGridSample.Data;
using BlazorServerDataGridSample.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerDataGridSample.Repositories;

public class SalesDetailRepository : DetailRepository<SampleDbContext, SalesDetail>, ISalesDetailRepository
{
    public SalesDetailRepository(IDbContextFactory<SampleDbContext> context, ILogger<SalesDetailRepository> logger)
        : base(context, logger)
    {
    }

    public void UpdateAll(IList<SalesDetail> entities)
    {
        using var context = _contextFactory.CreateDbContext();
        foreach (var item in entities)
        {
            if (item.Id != 0)
            {
                var entry = context.Set<SalesDetail>().Find(item.Id);
                _mapper.Map(item, entry);
            }
            else
            {
                context.Set<SalesDetail>().Add(item);
            }
        }

        try
        {
            context.SaveChanges();
            //_context.SaveChangesAsync() //非同期処理の場合はこちらを利用した実装に変更してください。
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex, ex.Message); // ログ出力等をここで実装
            throw;
        }
    }
}
