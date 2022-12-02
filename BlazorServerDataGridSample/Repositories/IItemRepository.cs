using BlazorServerDataGridSample.Data.Models;

namespace BlazorServerDataGridSample.Repositories
{
    /// <summary>
    /// マスターメンテ用Repositoryインターフェイス
    /// </summary>
    /// <typeparam name="TEntity">モデルを指定する</typeparam>
    public interface IItemRepository : IMasterRepository<Item>
    {


    }
}
