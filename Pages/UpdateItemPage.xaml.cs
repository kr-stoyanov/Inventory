using Inventory.ViewModels;

namespace Inventory.Pages;

public partial class UpdateItemPage : ContentPage
{
    private readonly UpdateItemViewModel _viewModel;

    public UpdateItemPage(UpdateItemViewModel viewModel)
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