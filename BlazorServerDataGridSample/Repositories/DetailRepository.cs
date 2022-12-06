using AutoMapper;
using BlazorServerDataGridSample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlazorServerDataGridSample.Repositories;

public class DetailRepository<TDbContext, TEntity> : IDetailRepository<TEntity> 
    where TDbContext : DbContext
    where TEntity : class
{
    protected readonly ILogger<IDetailRepository<TEntity>> _logger;

    protected readonly IDbContextFactory<TDbContext> _contextFactory;

    protected readonly IMapper _mapper;

    public DetailRepository(IDbContextFactory<TDbContext> contextFactory, ILogger<IDetailRepository<TEntity>> logger)
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

    public void Add(TEntity entity)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Set<TEntity>().Add(entity);
        context.SaveChanges();
        //_context.SaveChangesAsync() //非同期処理の場合はこちらを利用した実装に変更してください。
    }

    public TEntity Get(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<TEntity>().Find(id)!;
    }

    public IEnumerable<TEntity> GetAll()
    {
        using var context = _contextFactory.CreateDbContext();
        return context.Set<TEntity>().ToList();
    }

    public void Remove(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var entry = context.Set<TEntity>().Find(id);
        context.Set<TEntity>().Remove(entry!);
        context.SaveChanges();
        //_context.SaveChangesAsync() //非同期処理の場合はこちらを利用した実装に変更してください。
    }

    public void Update(TEntity entity, int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var entry = context.Set<TEntity>().Find(id);

        _mapper.Map(entity, entry);

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
