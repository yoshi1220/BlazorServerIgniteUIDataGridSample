using BlazorServerDataGridSample.Data;
using BlazorServerDataGridSample.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerDataGridSample.Repositories
{
    public class SalesDetailRepository : DetailRepository<SalesDetail>, ISalesDetailRepository
    {
        public SalesDetailRepository(SampleDbContext context, ILogger<SalesDetailRepository> logger)
            : base(context, logger)
        {

        }

        public SampleDbContext? SampleDbContext
        {
            get { return _context as SampleDbContext; }
        }

        public void UpdateAll(IList<SalesDetail> entities)
        {
            foreach (var item in entities)
            {
                if (item.Id != 0)
                {
                    var entry = _context.Set<SalesDetail>().Find(item.Id);
                    _mapper.Map(item, entry);
                }
                else
                {
                    _context.Set<SalesDetail>().Add(item);
                }

            }



            try
            {
                _context.SaveChanges();
                //_context.SaveChangesAsync() //非同期処理の場合はこちらを利用した実装に変更してください。
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex, ex.Message); // ログ出力等をここで実装
                throw;
            }

        }
    }

}
