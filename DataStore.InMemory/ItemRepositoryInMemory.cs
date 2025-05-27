using Inventory.Enums;
using Inventory.Models;
namespace Inventory.DataStore.InMemory;
public class ItemRepositoryInMemory : IItemRepositoryInMemory
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
                LastKnownLocation = $"Location of Item {index}",
                WarrantyExpirationDate = GetRandomWarrantyExpirationDate(),
                DateOfPurchase = DateOnly.FromDateTime(DateTime.Now.AddDays(-index)),
                ImageUrl = "images/icons8-item-50.png",
            })];
    }

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public IEnumerable<Item> GetAllItems() => _items;

    public Item? GetItemById(string id) => _items?.FirstOrDefault(x => x.Id.ToString() == id);

    public static T GetRandomEnum<T>() where T : Enum
    {
        var values = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        Random random = new();
        return values[random.Next(values.Length)];
    }

    private static DateOnly GetRandomWarrantyExpirationDate()
    {
        var random = new Random();
        // Range: from 1 year ago to 1 year in the future
        //int daysRange = 365 * 2;
        int randomDays = random.Next(-365, 365);
        return DateOnly.FromDateTime(DateTime.Today.AddDays(randomDays));
    }
}