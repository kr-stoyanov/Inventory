using Inventory.DataStote.Interfaces;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;

public class UpdateItemUsecase : IUpdateItemUsecase
{
    private readonly IItemRepository _itemRepository;

    public UpdateItemUsecase(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void Execute(Item item) => _itemRepository.UpdateItem(item);
}
