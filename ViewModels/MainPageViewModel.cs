using CommunityToolkit.Mvvm.Input;
using Inventory.Pages;
using System.Diagnostics;

namespace Inventory.ViewModels;
public partial class MainPageViewModel : BaseViewModel
{
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
}
