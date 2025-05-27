using Inventory.ViewModels;

namespace Inventory
{
    public partial class MainPage : ContentPage
    {
        private readonly ItemsViewModel _viewModel;

        public MainPage(ItemsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
    }
}
