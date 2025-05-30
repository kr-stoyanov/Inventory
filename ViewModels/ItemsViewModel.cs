using CommunityToolkit.Mvvm.Input;
using Inventory.Models;
using Inventory.Pages;
using Inventory.Usecases.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Inventory.ViewModels;

public partial class ItemsViewModel : BaseViewModel
{
    private readonly IItemsUsecase _itemUsecase;
    private readonly IRemoveItemUsecase _removeItemUsecase;

    public ObservableCollection<Item> Items { get; } = [];

    public ItemsViewModel(IItemsUsecase itemUsecase, IRemoveItemUsecase removeItemUsecase)
    {
        Title = "Items";
        _itemUsecase = itemUsecase;
        _removeItemUsecase = removeItemUsecase;
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
    async Task UpdateItemAsync(Item item)
    {
        if (item is null) return;
        await Shell.Current.GoToAsync($"{nameof(UpdateItemPage)}", true,
            new Dictionary<string, object>
            {
                { "Item", item }
            });
    }

    [RelayCommand]
    async Task AddItemAsync() => await Shell.Current.GoToAsync($"{nameof(AddItemPage)}", true);

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
    async Task RemoveItemAsync(Item item)
    {
        if (item is null) return;
        _removeItemUsecase.Execute(item);
        await Shell.Current.GoToAsync("..");
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
