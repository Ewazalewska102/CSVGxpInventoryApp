using CSVGxpInventoryApp.Views;

namespace CSVGxpInventoryApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddSystemPage), typeof(AddSystemPage));
            Routing.RegisterRoute(nameof(EditSystemPage), typeof(EditSystemPage));
            Routing.RegisterRoute(nameof(ReportPage), typeof(ReportPage));
        }
    }
}