using Inventory.DataStote.Interfaces;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;

public class EditItemUsecase : IEditItemUsecase
{
    private readonly IItemRepository _itemRepositoryInMemory;

    public EditItemUsecase(IItemRepository itemRepositoryInMemory)
    {
        _itemRepositoryInMemory = itemRepositoryInMemory;
    }

    public void Execute(Item item) => _itemRepositoryInMemory.EditItem(item);
}
