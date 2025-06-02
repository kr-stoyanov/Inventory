using Inventory.DataStote.Interfaces;
using Inventory.Enums;
using Inventory.Models;
namespace Inventory.DataStore.InMemory;
public class ItemRepositoryInMemory : IItemRepository
{
    private readonly List<Item> _items;

    public ItemRepositoryInMemory()
    {
        _items = [..Enumerable.Range(1, 25).Select(index => new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = $"Item {index}",
                Category = GetRandomEnum<ItemCategory>(),
                Make = $"Make {index}",
                Model = $"Model {index}",
                SerialNumber = $"SN-{Guid.NewGuid()}",
                Notes = $"Notes for Item {index}",
                WarrantyValidityMonths = (byte)new Random().Next(6, 36), // Random warranty validity between 1 and 36 months
                LastKnownLocation = $"Location of Item {index}",
                DateOfPurchase = DateOnly.FromDateTime(DateTime.Now.AddDays(-index)),
            })];
        _items.Insert(0, new Item
        {
            Id = Guid.NewGuid().ToString(),
            Name = "SSD",
            Category = ItemCategory.Electronics,
            Make = "Kingston",
            Model = "A400 - SA400S37/960G",
            SerialNumber = "V2119032",
            Notes = @"2.5"" SSD 960GB Purchased from Ardes.",
            WarrantyValidityMonths = 36, // 3 years warranty
            LastKnownLocation = "Mounted on the Desktop PC.",
            DateOfPurchase = DateOnly.FromDateTime(new DateTime(2025, 5, 24)),
        });
    }

    public void AddItem(Item item) => _items.Add(item);

    public IEnumerable<Item> GetAllItems() => _items.Where(x => !x.IsDeleted);

    public Item? GetItemById(string id) => _items?.FirstOrDefault(x => x.Id.ToString() == id);

    public void RemoveItem(Item item)
    {
        var itemToRemove = _items.FirstOrDefault(x => x.Id == item.Id);
        if (itemToRemove is not null) itemToRemove.IsDeleted = true;
    }

    public static T GetRandomEnum<T>() where T : Enum
    {
        var values = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        Random random = new();
        return values[random.Next(values.Length)];
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
                LastKnownLocation = item.LastKnownLocation,
                WarrantyValidityMonths = item.WarrantyValidityMonths,
                DateOfPurchase = item.DateOfPurchase,
            };
            _items[_items.IndexOf(itemToEdit)] = updatedItem;
        }
    }
}