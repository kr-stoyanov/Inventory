using Inventory.Constants;
using Inventory.Enums;

namespace Inventory.Extensions;

public static class CategoryExtensions
{
    private static readonly Dictionary<ItemCategory, string> _categoryImages = new()
    {
        { ItemCategory.Electronics, ApplicationConstants.Electronics },
        { ItemCategory.PowerTools, ApplicationConstants.PowerTools },
        { ItemCategory.Appliances, ApplicationConstants.Appliances },
        { ItemCategory.Tools,  ApplicationConstants.Tools },
        { ItemCategory.Miscellaneous, ApplicationConstants.Miscellaneous }
    };

    public static string GetCategoryImageUrl(this ItemCategory category)
    {
        if (_categoryImages.TryGetValue(category, out var imageUrl)) return imageUrl;
        
        return ApplicationConstants.Tools; // Fallback image
    }

}