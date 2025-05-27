using Inventory.DataStore.InMemory;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class AddItemUsecase : IAddItemUsecase
{
    private readonly IItemRepositoryInMemory _itemRepositoryInMemory;

    public AddItemUsecase(IItemRepositoryInMemory itemRepositoryInMemory)
    {
        _itemRepositoryInMemory = itemRepositoryInMemory;
    }

    public void Execute(Item item)
    {
        _itemRepositoryInMemory.AddItem(item);
    }
}