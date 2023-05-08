using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TakeNote.Data;

namespace TakeNote;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>().UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        //Database DI
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "TakeNote.db");
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<Repository>(s, dbPath));

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}