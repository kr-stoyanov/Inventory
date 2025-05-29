using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Models;
using Inventory.Pages;
using Inventory.Usecases.Interfaces;
using System.Diagnostics;

namespace Inventory.ViewModels;

[QueryProperty("Item", "Item")]
public partial class AddItemViewModel : BaseViewModel
{
    private readonly IAddItemUsecase _addItemUsecase;
    public AddItemViewModel(IAddItemUsecase addItemUsecase)
    {
        _addItemUsecase = addItemUsecase;
    }

    [ObservableProperty]
    Item _item;

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
            // TODO Add Logging
            Debug.WriteLine($"Error navigating back: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", $"There was an error navigating back. {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    async Task AddItemAsync(Item item)
    {
        if (item is null) return;
        _addItemUsecase.Execute(item);

        await Shell.Current.GoToAsync("..");
    }
}
