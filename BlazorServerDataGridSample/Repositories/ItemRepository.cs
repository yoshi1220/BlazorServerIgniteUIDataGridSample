using BlazorServerDataGridSample.Data;
using BlazorServerDataGridSample.Data.Models;
using BlazorServerDataGridSample.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerDataGridSample.Repositories
{

    public class ItemRepository : MasterRepository<Item>, IItemRepository
    {
        public ItemRepository(SampleDbContext context, ILogger<ItemRepository> logger)
        : base(context, logger)
        {

        }

        public SampleDbContext? SampleDbContext
        {
            get { return _context as SampleDbContext; }
        }


    }
}
