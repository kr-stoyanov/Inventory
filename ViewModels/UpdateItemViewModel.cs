using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Enums;
using Inventory.Models;
using Inventory.Usecases.Interfaces;
using System.Diagnostics;

namespace Inventory.ViewModels;

[QueryProperty("Item", "Item")]
public partial class UpdateItemViewModel : BaseViewModel
{
    private readonly IUpdateItemUsecase _editItemUsecase;

    public UpdateItemViewModel(IUpdateItemUsecase editItemUsecase)
    {
        Categories = [.. Enum.GetValues<ItemCategory>().Cast<ItemCategory>()];
        _editItemUsecase = editItemUsecase;
    }

    [ObservableProperty]
    private Item _item;

    partial void OnItemChanged(Item? value)
    {
        if (value != null)
            LoadItem(value);
    }

    public List<ItemCategory> Categories { get; }

    [ObservableProperty] string id = string.Empty;
    [ObservableProperty] string name = string.Empty;
    [ObservableProperty] ItemCategory category;
    [ObservableProperty] string make = string.Empty;
    [ObservableProperty] string model = string.Empty;
    [ObservableProperty] string serialNumber = string.Empty;
    [ObservableProperty] string notes = string.Empty;
    [ObservableProperty] string lastKnownLocation = string.Empty;
    [ObservableProperty] byte warrantyValidityMonths;
    [ObservableProperty] DateOnly dateOfPurchase;
    [ObservableProperty] string imageUrl = string.Empty;

    [RelayCommand]
    async Task SaveItemAsync()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            var updatedItem = new Item
            {
                Id = Id,
                Name = Name,
                Category = Category,
                Make = Make,
                Model = Model,
                SerialNumber = SerialNumber,
                Notes = Notes,
                LastKnownLocation = LastKnownLocation,
                WarrantyValidityMonths = WarrantyValidityMonths,
                DateOfPurchase = DateOfPurchase,
                ImageUrl = ImageUrl
            };
            _editItemUsecase.Execute(updatedItem);
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error saving item: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", $"There was an error saving the item. {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task GoBackAsync()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error navigating back: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", $"There was an error navigating back. {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    public void LoadItem(Item item)
    {
        if (item is null) return;
        Id = item.Id;
        Name = item.Name;
        Category = item.Category;
        Make = item.Make;
        Model = item.Model;
        SerialNumber = item.SerialNumber;
        Notes = item.Notes;
        LastKnownLocation = item.LastKnownLocation;
        WarrantyValidityMonths = item.WarrantyValidityMonths;
        DateOfPurchase = item.DateOfPurchase;
        ImageUrl = item.ImageUrl;
    }

}
