using Inventory.Models;

namespace Inventory.Usecases.Interfaces;
public interface IAddItemUsecase
{
    void Execute(Item item);
}
