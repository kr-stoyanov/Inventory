using Inventory.DataStore.InMemory;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class RemoveItemUsecase : IRemoveItemUsecase
{
    private readonly IItemRepositoryInMemory _itemRepositoryInMemory;

    public RemoveItemUsecase(IItemRepositoryInMemory itemRepositoryInMemory)
    {
        _itemRepositoryInMemory = itemRepositoryInMemory;
    }
    public void Execute(Item item) => _itemRepositoryInMemory.RemoveItem(item);
}
