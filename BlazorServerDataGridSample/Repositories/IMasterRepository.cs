namespace BlazorServerDataGridSample.Repositories;

/// <summary>
/// マスターメンテ用Repositoryインターフェイス
/// </summary>
/// <typeparam name="TEntity">モデルを指定する</typeparam>
public interface IMasterRepository<TEntity> where TEntity : class
{
    ValueTask<TEntity?> GetAsync(int id);

    ValueTask<IEnumerable<TEntity>> GetAllAsync();

    ValueTask AddAsync(TEntity entity);

    ValueTask UpdateAsync(TEntity entity, int id);

    ValueTask RemoveAsync(int id);
}
