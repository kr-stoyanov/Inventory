using Inventory.Models;

namespace Inventory.Usecases.Interfaces;
public interface IEditItemUsecase
{
    void Execute(Item item);
}
