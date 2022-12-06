using AutoMapper;
using BlazorServerDataGridSample.Data.Models;
using BlazorServerDataGridSample.Data.ViewModels;
using BlazorServerDataGridSample.Repositories;

namespace BlazorServerDataGridSample.Services;

public class SalesDetailService : ISalesDetailService
{
    private readonly ISalesDetailRepository _SalesDetailRepository;

    public SalesDetailService(ISalesDetailRepository SalesDetailRepository)
    {
        _SalesDetailRepository = SalesDetailRepository;
    }

    public void Add(SalesDetail entity)
    {
        _SalesDetailRepository.Add(entity);
    }

    public SalesDetail Get(int id)
    {
        return _SalesDetailRepository.Get(id);
    }

    /// <summary>
    /// ユーザーデータを全件取得
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SalesDetail> GetAll()
    {
        return _SalesDetailRepository.GetAll();
    }

    public IList<SalesDetailViewModel> GetDispAll()
    {
        var salesDetails = GetAll();
        List<SalesDetailViewModel> salesDetailViewModels = new();

        // Mapするモデルの設定
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SalesDetail, SalesDetailViewModel>();
        });

        // Mapperを作成
        var mapper = config.CreateMapper();

        foreach (var item in salesDetails)
        {
            var newItem = mapper.Map<SalesDetailViewModel>(item);
            salesDetailViewModels.Add(newItem);
        }

        return salesDetailViewModels;
    }

    public void Remove(int id)
    {
        _SalesDetailRepository.Remove(id);
    }

    public void Update(SalesDetail entity, int id)
    {
        _SalesDetailRepository.Update(entity, id);
    }

    public void UpdateAll(IList<SalesDetail> entities)
    {
        _SalesDetailRepository.UpdateAll(entities);
    }
}
