using Inventory.DataStore.InMemory;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class GetItemByIdUsecase : IGetItemByIdUsecase
{
    private readonly IItemRepositoryInMemory _itemRepositoryInMemory;

    public GetItemByIdUsecase(IItemRepositoryInMemory itemRepositoryInMemory)
    {  
        _itemRepositoryInMemory = itemRepositoryInMemory;
    }

    public Item Execute(string id)
    {
        return _itemRepositoryInMemory.GetItemById(id);
    }
}