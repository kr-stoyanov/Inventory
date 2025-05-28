using Inventory.Models;

namespace Inventory.Usecases.Interfaces;
public interface IRemoveItemUsecase
{
    void Execute(Item item);
}
