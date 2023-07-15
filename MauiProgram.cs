using Microsoft.Extensions.Logging;
using Disc.Services;
using Disc.Views;

namespace Disc;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

        //builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
        //builder.Services.AddSingleton<IRestService, RestService>();
        builder.Services.AddSingleton<IPostsService, PostsService>();

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddTransient<PostsPage>();

        return builder.Build();
	}
}
