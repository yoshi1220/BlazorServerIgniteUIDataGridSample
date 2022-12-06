namespace BlazorServerDataGridSample.Repositories;

/// <summary>
/// 明細入力用のRepositoryインターフェイス
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IDetailRepository<TEntity> where TEntity : class
{
    TEntity Get(int id);

    IEnumerable<TEntity> GetAll();

    void Add(TEntity entity);

    void Update(TEntity entity, int id);

    void Remove(int id);
}
