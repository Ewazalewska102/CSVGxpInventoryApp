using CSVGxpInventoryApp.ViewModels;

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
}