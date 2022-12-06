using AutoMapper;
using BlazorServerDataGridSample.Data.Models;
using BlazorServerDataGridSample.Data.ViewModels;
using BlazorServerDataGridSample.Repositories;

namespace BlazorServerDataGridSample.Services;

public class SalesDetailService : ISalesDetailService
{
    private readonly ISalesDetailRepository _SalesDetailRepository;

    private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<SalesDetail, SalesDetailViewModel>();
        cfg.CreateMap<SalesDetailViewModel, SalesDetail>();
    }).CreateMapper();

    public SalesDetailService(ISalesDetailRepository SalesDetailRepository)
    {
        _SalesDetailRepository = SalesDetailRepository;
    }

    public void Add(SalesDetailViewModel entity)
    {
        _SalesDetailRepository.Add(_mapper.Map<SalesDetail>(entity));
    }

    public SalesDetailViewModel Get(int id)
    {
        return _mapper.Map<SalesDetailViewModel>( _SalesDetailRepository.Get(id));
    }

    /// <summary>
    /// ユーザーデータを全件取得
    /// </summary>
    /// <returns></returns>
    public IEnumerable<SalesDetailViewModel> GetAll()
    {
        var salesDetails = _SalesDetailRepository.GetAll();
        return salesDetails
            .Select(_mapper.Map<SalesDetailViewModel>)
            .ToArray();
    }

    public void Remove(int id)
    {
        _SalesDetailRepository.Remove(id);
    }

    public void Update(SalesDetailViewModel entity, int id)
    {
        _SalesDetailRepository.Update(_mapper.Map<SalesDetail>(entity), id);
    }

    public void UpdateAll(IList<SalesDetailViewModel> entities)
    {
        _SalesDetailRepository.UpdateAll(entities.Select(_mapper.Map<SalesDetail>).ToList());
    }
}
