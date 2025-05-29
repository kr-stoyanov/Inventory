using Inventory.Enums;

namespace Inventory.Models;

public class Item
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required ItemCategory Category { get; init; }
    public required string Make { get; init; }
    public required string Model { get; init; }
    public required string SerialNumber { get; init; }
    public required string Notes { get; init; }
    public bool IsDeleted { get; set; }
    public required string LastKnownLocation { get; init; }
    public required byte WarrantyValidityMonths { get; init; }
    public required DateOnly DateOfPurchase { get; init; }
    public required string ImageUrl { get; init; }
    public DateOnly WarrantyExpirationDate { get => DateOfPurchase.AddMonths(WarrantyValidityMonths); }
    public WarrantyStatus WarrantyStatus
    {
        get
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            return WarrantyExpirationDate switch
            {
                var day when day < today => WarrantyStatus.Expired,
                var day when day <= today.AddDays(30) => WarrantyStatus.ExpiringSoon,
                _ => WarrantyStatus.Active
            };
        }
    }
}

