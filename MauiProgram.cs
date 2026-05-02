using Microsoft.Extensions.Logging;
using CSVGxpInventoryApp.Services;
using CSVGxpInventoryApp.Repositories;
using CSVGxpInventoryApp.ViewModels;
using CSVGxpInventoryApp.Views;

namespace CSVGxpInventoryApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Services
            builder.Services.AddSingleton<DatabaseService>();

            // Repositories
            builder.Services.AddSingleton<SystemRepository>();

            // ViewModels
            builder.Services.AddSingleton<SystemViewModel>();

            // Pages
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<AddSystemPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}