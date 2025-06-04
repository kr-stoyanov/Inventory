using Inventory.DataStote.Interfaces;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class GetItemByIdUsecase : IGetItemByIdUsecase
{
    private readonly IItemRepository _itemRepository;

    public GetItemByIdUsecase(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public Item Execute(string id) => _itemRepository.GetItemById(id);
}