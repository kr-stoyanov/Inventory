using Inventory.Pages;

namespace Inventory
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailsPage), typeof(ItemDetailsPage));
            Routing.RegisterRoute(nameof(ItemsPage), typeof(ItemsPage));
        }
    }
}
