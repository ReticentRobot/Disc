using Microsoft.Extensions.Logging;
using Disc.Interfaces;
using Disc.Services;
using Disc.Views;
using Disc.ViewModels;
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Disc;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            // Initialize the .NET MAUI Community Toolkit by adding the below line of code
            .UseMauiCommunityToolkit()
            // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            ;

        // Continue initializing your .NET MAUI App here
        builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
        builder.Services.AddSingleton<IRestService, RestService>();
        builder.Services.AddSingleton<IPostsService, PostsService>();
        builder.Services.AddSingleton<ILoginService, LoginService>();
        //builder.Services.AddTransient<IPostsViewModel, PostsViewModel>();

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddTransient<PostsPage>();
        builder.Services.AddTransient<SettingsPage>();

        return builder.Build();
    }
}
