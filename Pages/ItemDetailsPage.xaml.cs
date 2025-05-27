using Inventory.ViewModels;

namespace Inventory.Pages;

public partial class ItemDetailsPage : ContentPage
{
    private readonly ItemDetailsViewModel _viewModel;

    public ItemDetailsPage(ItemDetailsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}