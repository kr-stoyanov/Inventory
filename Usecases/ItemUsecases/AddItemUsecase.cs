using Inventory.DataStote.Interfaces;
using Inventory.Models;
using Inventory.Usecases.Interfaces;

namespace Inventory.Usecases.ItemUsecases;
public class AddItemUsecase : IAddItemUsecase
{
    private readonly IItemRepository _itemRepository;

    public AddItemUsecase(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public void Execute(Item item) => _itemRepository.AddItem(item);

}