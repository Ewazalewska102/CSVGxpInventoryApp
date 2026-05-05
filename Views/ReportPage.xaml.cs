using CSVGxpInventoryApp.ViewModels;

namespace CSVGxpInventoryApp.Views;

public partial class ReportPage : ContentPage
{
    private readonly SystemViewModel _viewModel;

    public ReportPage(SystemViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadSystemsAsync();
    }
}