using Inventory.DataStote.Interfaces;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class AddItemUsecase : IAddItemUsecase
{
    private readonly IItemRepository _itemRepositoryInMemory;

    public AddItemUsecase(IItemRepository itemRepositoryInMemory)
    {
        _itemRepositoryInMemory = itemRepositoryInMemory;
    }

    public void Execute(Item item) => _itemRepositoryInMemory.AddItem(item);
    
}