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
}