using Inventory.DataStore.InMemory;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class ItemUsecase : IItemUsecase
{
    private readonly IItemRepositoryInMemory _itemRepositoryInMemory;

    public ItemUsecase(IItemRepositoryInMemory itemRepositoryInMemory)
    {
        _itemRepositoryInMemory = itemRepositoryInMemory;
    }

    public IEnumerable<Item> Execute()
    {
        return _itemRepositoryInMemory.GetAllItems();
    }
}
