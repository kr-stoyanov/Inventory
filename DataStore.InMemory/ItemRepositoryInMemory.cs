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
                WarrantyValidityMonths = (byte)new Random().Next(6, 36), // Random warranty validity between 1 and 36 months
                LastKnownLocation = $"Location of Item {index}",
                DateOfPurchase = DateOnly.FromDateTime(DateTime.Now.AddDays(-index)),
                ImageUrl = "../Resources/Images/icons8_tools_48.png",
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
            ImageUrl = "../Resources/Images/icons8_tools_48.png"
        });
    }

    public void AddItem(Item item) => _items.Add(item);

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