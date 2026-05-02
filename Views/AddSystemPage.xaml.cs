using CSVGxpInventoryApp.ViewModels;

namespace CSVGxpInventoryApp.Views;

public partial class AddSystemPage : ContentPage
{
    private readonly SystemViewModel _viewModel;

    public AddSystemPage(SystemViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void OnSaveSystemClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_viewModel.SystemName) ||
            string.IsNullOrWhiteSpace(_viewModel.SelectedDepartment) ||
            string.IsNullOrWhiteSpace(_viewModel.Owner) ||
            string.IsNullOrWhiteSpace(_viewModel.Vendor) ||
            string.IsNullOrWhiteSpace(_viewModel.ValidationStatus))
        {
            await DisplayAlert("Missing Information", "Please complete all fields before saving.", "OK");
            return;
        }

        await _viewModel.AddSystemAsync();

        await DisplayAlert("Saved", "System record has been added to the inventory.", "OK");

        await Shell.Current.GoToAsync("..");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}