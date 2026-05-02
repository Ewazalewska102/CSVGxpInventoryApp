using CSVGxpInventoryApp.Models;
using CSVGxpInventoryApp.ViewModels;
using CSVGxpInventoryApp.Views;

namespace CSVGxpInventoryApp;

public partial class MainPage : ContentPage
{
    private readonly SystemViewModel _viewModel;

    public MainPage(SystemViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadSystemsAsync();
    }

    private async void OnAddSystemClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddSystemPage));
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is SystemEntity selectedSystem)
        {
            _viewModel.SelectedSystem = selectedSystem;

            await Shell.Current.GoToAsync(nameof(EditSystemPage));
        }
    }

    private async void OnMarkAsObsoleteClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is SystemEntity selectedSystem)
        {
            bool confirm = await DisplayAlert(
                "Mark as Obsolete",
                $"Are you sure you want to mark '{selectedSystem.SystemName}' as obsolete?",
                "Yes",
                "No");

            if (!confirm)
                return;

            await _viewModel.MarkSystemAsObsoleteAsync(selectedSystem);

            await DisplayAlert(
                "System Obsolete",
                "The system has been marked as obsolete and removed from the active inventory list.",
                "OK");
        }
    }
}