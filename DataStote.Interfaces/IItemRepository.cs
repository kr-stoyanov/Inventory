using Inventory.Models;

namespace Inventory.DataStote.Interfaces;
public interface IItemRepository
{
    IEnumerable<Item> GetAllItems();
    Item? GetItemById(string id);
    void AddItem(Item item);
    void RemoveItem(Item item);

    void EditItem(Item item);
}

