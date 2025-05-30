using Inventory.DataStote.Interfaces;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;

public class UpdateItemUsecase : IUpdateItemUsecase
{
    private readonly IItemRepository _itemRepositoryInMemory;

    public UpdateItemUsecase(IItemRepository itemRepositoryInMemory)
    {
        _itemRepositoryInMemory = itemRepositoryInMemory;
    }

    public void Execute(Item item) => _itemRepositoryInMemory.UpdateItem(item);
}
