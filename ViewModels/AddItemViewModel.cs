using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Enums;
using Inventory.Models;
using Inventory.Usecases.Interfaces;
using System.Diagnostics;

namespace Inventory.ViewModels;

public partial class AddItemViewModel : BaseViewModel
{
    private readonly IAddItemUsecase _addItemUsecase;

    public AddItemViewModel(IAddItemUsecase addItemUsecase)
    {
        _addItemUsecase = addItemUsecase;
        Categories = [.. Enum.GetValues<ItemCategory>().Cast<ItemCategory>()];
        DateOfPurchase = DateOnly.FromDateTime(DateTime.Today);
    }

    public List<ItemCategory> Categories { get; set; }

    [ObservableProperty] string _name = string.Empty;
    [ObservableProperty] ItemCategory _category;
    [ObservableProperty] string _make = string.Empty;
    [ObservableProperty] string _model = string.Empty;
    [ObservableProperty] string _serialNumber = string.Empty;
    [ObservableProperty] string _notes = string.Empty;
    [ObservableProperty] string _lastKnownLocation = string.Empty;
    [ObservableProperty] byte _warrantyValidityMonths;
    [ObservableProperty] DateOnly _dateOfPurchase;

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

    [RelayCommand]
    async Task AddItemAsync()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            var item = new Item
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Category = Category,
                Make = Make,
                Model = Model,
                SerialNumber = SerialNumber,
                Notes = Notes,
                LastKnownLocation = LastKnownLocation,
                WarrantyValidityMonths = WarrantyValidityMonths,
                DateOfPurchase = DateOfPurchase,
                ImageUrl = "../Resources/Images/icons8_tools_48.png"
            };
            _addItemUsecase.Execute(item);
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error adding item: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", $"There was an error adding the item. {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
