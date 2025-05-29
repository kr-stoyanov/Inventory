using Inventory.DataStote.Interfaces;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class RemoveItemUsecase : IRemoveItemUsecase
{
    private readonly IItemRepository _itemRepositoryInMemory;

    public RemoveItemUsecase(IItemRepository itemRepositoryInMemory)
    {
        _itemRepositoryInMemory = itemRepositoryInMemory;
    }
    public void Execute(Item item) => _itemRepositoryInMemory.RemoveItem(item);
}
