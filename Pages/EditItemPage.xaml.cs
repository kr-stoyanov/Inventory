using Inventory.ViewModels;

namespace Inventory.Pages;

public partial class EditItemPage : ContentPage
{
    private readonly EditItemViewModel _viewModel;

    public EditItemPage(EditItemViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if (_viewModel.Item is not null) _viewModel.LoadItem(_viewModel.Item);
    }
}