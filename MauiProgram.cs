using CommunityToolkit.Maui;
using Disc.Services;
using Disc.Views;
using System.Diagnostics;

namespace Disc;

[XamlCompilation(XamlCompilationOptions.Skip)]
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            // Intialize the Sentry debug package
            .UseSentry(options => {
                // The DSN is the only required setting.
                options.Dsn = "https://d4d062878d558608b3fd627df09c70cd@o4505726728011776.ingest.sentry.io/4505726730240000";

                // Use debug mode if you want to see what the SDK is doing.
                // Debug messages are written to stdout with Console.Writeline,
                // and are viewable in your IDE's debug console or with 'adb logcat', etc.
                // This option is not recommended when deploying your application.
                options.Debug = true;

                // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                options.TracesSampleRate = 1.0;

                // Other Sentry options can be set here.
            })
            // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            .UseMauiCommunityToolkit()
            // After initializing the .NET MAUI Community Toolkit, optiony add additional fonts
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            ;
        // TODO: Add light mode support, for now - setting app to always load in dark mode
        // Application.Current.UserAppTheme = AppTheme.Dark;

        builder.Services.AddSingleton<RestService>(new RestService(Constants.RestUrl));

        //builder.Services.AddSingleton<ILoginService, LoginService>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddTransient<WebViewPage>();
        builder.Services.AddTransient<ImagePage>();

        return builder.Build();
    }
}
