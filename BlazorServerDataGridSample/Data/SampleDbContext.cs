using BlazorServerDataGridSample.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerDataGridSample.Data;

public class SampleDbContext : DbContext
{

    public DbSet<SalesDetail> SalesDetails { get; set; }

    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SalesDetail>()
            .ToTable("SalesDetails");
        modelBuilder.Entity<SalesDetail>()
            .HasData(
                new SalesDetail
                {
                    Id = 1,
                    SlipNumber = 10001,
                    RowNumber = 1,
                    ItemCode = "S001",
                    ItemName = "商品1",
                    Quantity = 3,
                    UnitPrice = 330,
                    Amount = 990,
                    SalesTax = 99
                }
            );
    }
}
}
