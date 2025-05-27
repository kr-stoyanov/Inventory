using CommunityToolkit.Mvvm.Input;
using Inventory.Models;
using Inventory.Pages;
using Inventory.Usecases.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Inventory.ViewModels;

public partial class ItemsViewModel : BaseViewModel
{
    private readonly IItemUsecase _itemUsecase;

    public ObservableCollection<Item> Items { get; } = [];

    public ItemsViewModel(IItemUsecase itemUsecase)
    {
        Title = "Items";
        _itemUsecase = itemUsecase;
    }

    [RelayCommand]
    async Task GoToDetailsAsync(Item item)
    {
        if (item is null) return;
        await Shell.Current.GoToAsync($"{nameof(ItemDetailsPage)}", true,
            new Dictionary<string, object>
            {
                { "Item", item }
            });
    }

    [RelayCommand]
    async Task LoadItemsAsync()
    {
        if (IsBusy) return;
        try
        {
            IsBusy = true;
            var items = _itemUsecase.Execute();

            if (Items.Count != 0) Items.Clear();

            items.ToList().ForEach(Items.Add);
        }
        catch (Exception ex)
        {
            // TODO Add Logging
            Debug.WriteLine($"Error loading items: {ex.Message}");
            await Shell.Current.DisplayAlert("Error", $"There was an error loading the items.  {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
