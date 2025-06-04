using Inventory.DataStote.Interfaces;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class ItemsUsecase : IItemsUsecase
{
    private readonly IItemRepository _itemRepository;

    public ItemsUsecase(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public IEnumerable<Item> Execute() => _itemRepository.GetAllItems();
}
