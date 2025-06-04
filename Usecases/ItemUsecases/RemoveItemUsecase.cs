using Inventory.DataStote.Interfaces;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class RemoveItemUsecase : IRemoveItemUsecase
{
    private readonly IItemRepository _itemRepository;

    public RemoveItemUsecase(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    public void Execute(Item item) => _itemRepository.RemoveItem(item);
}
