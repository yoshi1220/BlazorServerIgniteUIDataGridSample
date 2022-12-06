using BlazorServerDataGridSample.Data;
using BlazorServerDataGridSample.Data.Models;
using BlazorServerDataGridSample.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerDataGridSample.Repositories
{

    public class ItemRepository : MasterRepository<SampleDbContext, Item>, IItemRepository
    {
        public ItemRepository(IDbContextFactory<SampleDbContext> context, ILogger<ItemRepository> logger)
        : base(context, logger)
        {

        }

        //public SampleDbContext? SampleDbContext
        //{
        //    get { return _context as SampleDbContext; }
        //}


    }
}
