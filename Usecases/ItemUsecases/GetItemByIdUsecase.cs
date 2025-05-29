using Inventory.DataStote.Interfaces;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class GetItemByIdUsecase : IGetItemByIdUsecase
{
    private readonly IItemRepository _itemRepositoryInMemory;

    public GetItemByIdUsecase(IItemRepository itemRepositoryInMemory)
    {  
        _itemRepositoryInMemory = itemRepositoryInMemory;
    }

    public Item Execute(string id)
    {
        return _itemRepositoryInMemory.GetItemById(id);
    }
}