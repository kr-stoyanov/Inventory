using Inventory.DataStore.InMemory;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class ItemsUsecase : IItemsUsecase
{
    private readonly IItemRepositoryInMemory _itemRepositoryInMemory;

    public ItemsUsecase(IItemRepositoryInMemory itemRepositoryInMemory)
    {
        _itemRepositoryInMemory = itemRepositoryInMemory;
    }

    public IEnumerable<Item> Execute() => _itemRepositoryInMemory.GetAllItems();
}
