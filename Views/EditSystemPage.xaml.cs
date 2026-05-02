using CSVGxpInventoryApp.Models;
using CSVGxpInventoryApp.ViewModels;

namespace CSVGxpInventoryApp.Views;

public partial class EditSystemPage : ContentPage
{
    private readonly SystemViewModel _viewModel;

    public EditSystemPage(SystemViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (_viewModel.SelectedSystem == null)
            return;

        await _viewModel.UpdateSystemAsync(_viewModel.SelectedSystem);

        await DisplayAlert("Saved", "System updated successfully.", "OK");

        await Shell.Current.GoToAsync("..");
    }
}