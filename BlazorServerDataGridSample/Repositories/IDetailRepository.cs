namespace BlazorServerDataGridSample.Repositories;

/// <summary>
/// 明細入力用のRepositoryインターフェイス
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IDetailRepository<TEntity> where TEntity : class
{
    ValueTask<TEntity?> GetAsync(int id);

    ValueTask<IEnumerable<TEntity>> GetAllAsync();

    ValueTask AddAsync(TEntity entity);

    ValueTask UpdateAsync(TEntity entity, int id);

    ValueTask RemoveAsync(int id);
}
