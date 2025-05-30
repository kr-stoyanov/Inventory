using Inventory.Models;

namespace Inventory.Usecases.Interfaces;
public interface IUpdateItemUsecase
{
    void Execute(Item item);
}
