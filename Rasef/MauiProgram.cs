using Microsoft.Extensions.Logging;
using Rasef.Localization;

namespace Rasef
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
                });

            // Add Blazor WebView
            builder.Services.AddMauiBlazorWebView();

            // Register CultureService as Singleton (CRITICAL!)
            builder.Services.AddSingleton<CultureService>();

            // Add Localization services
            builder.Services.AddLocalization();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}