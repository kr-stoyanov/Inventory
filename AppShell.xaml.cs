using Inventory.Pages;

namespace Inventory
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailsPage), typeof(ItemDetailsPage));
        }
    }
}
