using System.ComponentModel.DataAnnotations;

namespace Inventory.Enums;
public enum WarrantyStatus
{
    Active = 2,

    [DisplayAttribute(Name = "Expiring Soon")]
    ExpiringSoon = 4,

    Expired = 8
}