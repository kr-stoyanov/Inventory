using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using Inventory.DataStote.Interfaces;
using Inventory.Pages;
using System.Diagnostics;

namespace Inventory.ViewModels;
public partial class MainPageViewModel : BaseViewModel
{
    private readonly IItemRepository _itemRepository;

    public MainPageViewModel(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    [RelayCommand]
    async Task GoToItemsAsync()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(ItemsPage), true);
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
    async Task DropDatabaseAsync()
    {
        if (IsBusy) return;
        _itemRepository.DropDatabase();

        var toast = Toast.Make("Successfully Dropped Database and Cleared the Cache!", ToastDuration.Short);
        await toast.Show();
    }
}
