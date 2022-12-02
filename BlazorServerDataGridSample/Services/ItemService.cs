using AutoMapper;
using BlazorServerDataGridSample.Data.Models;
using BlazorServerDataGridSample.Data.ViewModels;
using BlazorServerDataGridSample.Repositories;

namespace BlazorServerDataGridSample.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _ItemRepository;

        public ItemService(IItemRepository ItemRepository)
        {
            _ItemRepository = ItemRepository;
        }

        public void Add(Item entity)
        {
            _ItemRepository.Add(entity);
        }

        public Item Get(int id)
        {
            return _ItemRepository.Get(id);
        }

        /// <summary>
        /// ユーザーデータを全件取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Item> GetAll()
        {
            return _ItemRepository.GetAll();
        }


        public IList<ItemViewModel> GetDispAll()
        {
            var items = GetAll();
            List<ItemViewModel> itemViewModels = new();

            // Mapするモデルの設定
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemViewModel>();
            });

            // Mapperを作成
            var mapper = config.CreateMapper();

            foreach (var item in items)
            {
                var newItem = mapper.Map<ItemViewModel>(item);
                itemViewModels.Add(newItem);
            }

            return itemViewModels;
        }

        public void Remove(int id)
        {
            _ItemRepository.Remove(id);
        }

        public void Update(Item entity, int id)
        {
            _ItemRepository.Update(entity, id);
        }

    }
}
