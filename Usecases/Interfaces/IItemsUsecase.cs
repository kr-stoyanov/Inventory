using Inventory.Models;

namespace Inventory.Usecases.Interfaces;
public interface IItemsUsecase
{
    IEnumerable<Item> Execute();
}
