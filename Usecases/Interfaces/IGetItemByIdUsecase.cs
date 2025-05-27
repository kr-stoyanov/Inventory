using Inventory.Models;

namespace Inventory.Usecases.Interfaces;
public interface IGetItemByIdUsecase
{
    Item Execute(string id);
}

