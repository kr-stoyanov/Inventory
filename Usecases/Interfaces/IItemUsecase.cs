using Inventory.Models;

namespace Inventory.Usecases.Interfaces;
public interface IItemUsecase
{
    IEnumerable<Item> Execute();
}
