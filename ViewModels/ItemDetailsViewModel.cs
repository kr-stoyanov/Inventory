﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Inventory.Models;
using System.Diagnostics;

namespace Inventory.ViewModels
{
    [QueryProperty("Item", "Item")]
    public partial class ItemDetailsViewModel : BaseViewModel
    {
        public ItemDetailsViewModel()
        {
            Title = "Item Details";
        }

        [ObservableProperty]
        Item? _item;

        public string DateOfPurchaseDisplay =>
         Item is not null ? Item.DateOfPurchase.ToString("yyyy-MM-dd") : string.Empty;


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
        static async Task PrintWarrantyAsync()
        {
            Debug.WriteLine("Print Functionality is not implemented yet!");
            await Shell.Current.DisplayAlert("Print", "Print Functionality is not implemented yet!", "OK");
        }
    }
}
