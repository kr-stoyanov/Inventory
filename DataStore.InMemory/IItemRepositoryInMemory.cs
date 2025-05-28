using Inventory.Models;

namespace Inventory.DataStore.InMemory;
public interface IItemRepositoryInMemory
{
    IEnumerable<Item> GetAllItems();
    Item? GetItemById(string id);
    void AddItem(Item item);
    void RemoveItem(Item item);
}

