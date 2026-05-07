namespace CSVGxpInventoryApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text?.Trim().ToLower() ?? string.Empty;
        string password = PasswordEntry.Text ?? string.Empty;

        if (username == "admin" && password == "admin123")
        {
            Application.Current!.MainPage = new AppShell();
            return;
        }

        await DisplayAlert(
            "Login Failed",
            "Invalid username or password.",
            "OK");
    }
}