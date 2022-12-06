using AutoMapper;
using BlazorServerDataGridSample.Data.Models;
using BlazorServerDataGridSample.Data.ViewModels;
using BlazorServerDataGridSample.Repositories;

namespace BlazorServerDataGridSample.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _ItemRepository;

        private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Item, ItemViewModel>();
            cfg.CreateMap<ItemViewModel, Item>();
        }).CreateMapper();

        public ItemService(IItemRepository ItemRepository)
        {
            _ItemRepository = ItemRepository;
        }

        public ValueTask AddAsync(Item entity)
        {
            return _ItemRepository.AddAsync(_mapper.Map<Item>(entity));
        }

        public async ValueTask<Item?> GetAsync(int id)
        {
            return await _ItemRepository.GetAsync(id);
        }


        /// <summary>
        /// ユーザーデータを全件取得
        /// </summary>
        /// <returns></returns>
        public async ValueTask<IEnumerable<Item>> GetAllAsync()
        {
            return await _ItemRepository.GetAllAsync();
        }


        public async ValueTask<IEnumerable<ItemViewModel>> GetDispAllAsync()
        {
            var items = await _ItemRepository.GetAllAsync();
            return items
                .Select(_mapper.Map<ItemViewModel>)
                .ToArray();
        }


        public ValueTask RemoveAsync(int id)
        {
            return _ItemRepository.RemoveAsync(id);
        }

        public ValueTask UpdateAsync(Item entity, int id)
        {
            return _ItemRepository.UpdateAsync(_mapper.Map<Item>(entity), id);
        }

    }
}
