using Inventory.DataStote.Interfaces;
using Inventory.Models;
using System.Text.Json;

namespace Inventory.DataStore.LocalFile;

public class ItemRepositoryLocalFile : IItemRepository
{
    private readonly string _appDataFile = $"{FileSystem.AppDataDirectory}\\appData.json";
    private readonly List<Item> _items;

    public ItemRepositoryLocalFile()
    {
        _items = LoadItems();
    }

    public IEnumerable<Item> GetAllItems() => _items.Where(x => !x.IsDeleted);

    public Item GetItemById(string id) => _items.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Item with ID {id} not found.");

    public void AddItem(Item item)
    {
        _items.Add(item);
        SaveItems();
    }

    public void RemoveItem(Item item)
    {
        var itemToRemove = _items.FirstOrDefault(x => x.Id == item.Id);
        if (itemToRemove is not null)
        {
            itemToRemove.IsDeleted = true;
            SaveItems();
        }
    }

    private List<Item> LoadItems()
    {
        if (!File.Exists(_appDataFile)) return [];
        var json = File.ReadAllText(_appDataFile);
        return JsonSerializer.Deserialize<List<Item>>(json) ?? [];
    }

    private void SaveItems()
    {
        var json = JsonSerializer.Serialize(_items);
        File.WriteAllText(_appDataFile, json);
    }

    public void UpdateItem(Item item)
    {
        var itemToEdit = _items.FirstOrDefault(x => x.Id == item.Id);
        if (itemToEdit is not null)
        {
            // Create a new instance of the Item with updated properties
            var updatedItem = new Item
            {
                Id = itemToEdit.Id, // Preserve the original ID
                Name = item.Name,
                Category = item.Category,
                Make = item.Make,
                Model = item.Model,
                SerialNumber = item.SerialNumber,
                Notes = item.Notes,
                IsDeleted = itemToEdit.IsDeleted, // Preserve the IsDeleted state
                LastKnownLocation = item.LastKnownLocation,
                WarrantyValidityMonths = item.WarrantyValidityMonths,
                DateOfPurchase = item.DateOfPurchase,
                ReceiptImageUrl = item.ReceiptImageUrl
            };

            // Replace the old item with the updated one
            _items[_items.IndexOf(itemToEdit)] = updatedItem;
            SaveItems();
        }
    }

    public void DropDatabase()
    {
        if (File.Exists(_appDataFile)) File.Delete(_appDataFile);

        _items.Clear();
    }
}
