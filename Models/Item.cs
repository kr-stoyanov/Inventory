using Inventory.Enums;
using Inventory.Extensions;

namespace Inventory.Models;

[Serializable]
public class Item
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required ItemCategory Category { get; init; }
    public required string Make { get; init; }
    public required string Model { get; init; }
    public required string SerialNumber { get; init; }
    public required string Notes { get; init; }
    public required string LastKnownLocation { get; init; }
    public required byte WarrantyValidityMonths { get; init; }
    public required DateTime DateOfPurchase { get; set; }
    public required string ReceiptImageUrl { get; set; }
    public bool IsDeleted { get; set; }
    public string CategoryImageUrl { get => Category.GetCategoryImageUrl(); }
    public DateTime WarrantyExpirationDate { get => DateOfPurchase.AddMonths(WarrantyValidityMonths); }
    public WarrantyStatus WarrantyStatus
    {
        get
        {
            var today = DateTime.Today;
            return WarrantyExpirationDate switch
            {
                var day when day <= today => WarrantyStatus.Expired,
                var day when day <= today.AddDays(30) => WarrantyStatus.ExpiringSoon,
                _ => WarrantyStatus.Active
            };
        }
    }
}

