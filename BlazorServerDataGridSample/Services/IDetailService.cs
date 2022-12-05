namespace BlazorServerDataGridSample.Services;

/// <summary>
/// 明細入力用サービスインターフェース
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IDetailService<TEntity>
{
    TEntity Get(int id);

    IEnumerable<TEntity> GetAll();

    void Add(TEntity entity);

    void Update(TEntity entity, int id);

    void UpdateAll(IList<TEntity> entities);

    void Remove(int id);
}
