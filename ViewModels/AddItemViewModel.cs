using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
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
        Title = "Add New Item";
        Categories = [.. Enum.GetValues<ItemCategory>().Cast<ItemCategory>()];
        DateOfPurchase = DateTime.Today;
        Category = ItemCategory.Tools; // Default category
    }

    private ImageSource? _selectedPhoto;
    public ImageSource? SelectedPhoto
    {
        get => _selectedPhoto;
        set => SetProperty(ref _selectedPhoto, value);
    }

    private readonly string _localFilePath = Path.Combine(FileSystem.CacheDirectory, Guid.NewGuid().ToString());

    public List<ItemCategory> Categories { get; set; }

    [ObservableProperty] string _name = string.Empty;
    [ObservableProperty] ItemCategory _category;
    [ObservableProperty] string _make = string.Empty;
    [ObservableProperty] string _model = string.Empty;
    [ObservableProperty] string _serialNumber = string.Empty;
    [ObservableProperty] string _notes = string.Empty;
    [ObservableProperty] string _lastKnownLocation = string.Empty;
    [ObservableProperty] byte _warrantyValidityMonths;
    [ObservableProperty] DateTime _dateOfPurchase;

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
    async Task TakePhotoAsync()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.Camera>();

        if (status != PermissionStatus.Granted)
        {
            status = await Permissions.RequestAsync<Permissions.Camera>();

            if (status != PermissionStatus.Granted)
            {
                // Handle the case where the user denied the permission
                // Show an alert or prompt the user to change the permission in settings
            }
        }

        if (status == PermissionStatus.Granted)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult? photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {


                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(_localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);
                    SelectedPhoto = ImageSource.FromStream(() => File.OpenRead(_localFilePath));
                }
            }

            var toast = Toast.Make("Photo successfully uploaded!", ToastDuration.Short);
            await toast.Show();
        }
    }

    [RelayCommand]
    void RemovePhoto()
    {
        SelectedPhoto = null;
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
                ReceiptImageUrl = _localFilePath,
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
