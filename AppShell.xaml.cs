using CSVGxpInventoryApp.Views;

namespace CSVGxpInventoryApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddSystemPage), typeof(AddSystemPage));
        }
    }
}