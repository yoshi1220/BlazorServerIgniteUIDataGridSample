using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerDataGridSample.Repositories;

public class MasterRepository<TDbContext, TEntity> : IMasterRepository<TEntity> 
    where TDbContext : DbContext
    where TEntity : class
{

    private readonly ILogger<IMasterRepository<TEntity>> _logger;

    protected readonly IDbContextFactory<TDbContext> _contextFactory;

    protected readonly IMapper _mapper;

    public MasterRepository(IDbContextFactory<TDbContext> contextFactory, ILogger<IMasterRepository<TEntity>> logger)
    {
        _contextFactory = contextFactory;
        _logger = logger;

        // Mapするモデルの設定
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TEntity, TEntity>();
        });

        // Mapperを作成
        _mapper = config.CreateMapper();
    }

    public async ValueTask AddAsync(TEntity entity)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        await context.Set<TEntity>().AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async ValueTask<TEntity?> GetAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Set<TEntity>().FindAsync(id)!;
    }

    public virtual async ValueTask<IEnumerable<TEntity>> GetAllAsync()
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Set<TEntity>().ToArrayAsync();
    }

    public async ValueTask RemoveAsync(int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var entry = await context.Set<TEntity>().FindAsync(id);
        if (entry == null) throw new InvalidOperationException($"指定されたエンティティを削除しようとしましたが見つかりません。id = {id}");

        context.Set<TEntity>().Remove(entry);
        await context.SaveChangesAsync();
    }

    public async ValueTask UpdateAsync(TEntity entity, int id)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var entry = await context.Set<TEntity>().FindAsync(id);
        if (entry == null) throw new InvalidOperationException($"指定されたエンティティを更新しようとしましたが見つかりません。id = {id}");

        _mapper.Map(entity, entry);

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex, ex.Message); // ログ出力等をここで実装
            throw;
        }
    }
}
