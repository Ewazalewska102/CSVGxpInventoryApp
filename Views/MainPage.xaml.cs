using CSVGxpInventoryApp.Models;
using CSVGxpInventoryApp.Services;

namespace CSVGxpInventoryApp;

public partial class MainPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public MainPage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var systems = await _databaseService.GetSystemsAsync();

        // Only insert sample data if database is empty
        if (systems.Count == 0)
        {
            var department = new Department
            {
                Name = "Quality Assurance"
            };

            await _databaseService.AddDepartmentAsync(department);

            var system = new SystemEntity
            {
                SystemName = "TrackWise",
                DepartmentId = 1,
                Owner = "QA Manager",
                Vendor = "Sparta Systems",
                ValidationStatus = "Validated"
            };

            await _databaseService.AddSystemAsync(system);

            systems = await _databaseService.GetSystemsAsync();
        }

        MainLabel.Text = $"Systems in DB: {systems.Count}";
    }
}