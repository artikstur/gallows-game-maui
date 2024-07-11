using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace GallowsGame
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
                    fonts.AddFont("Maki-Sans.ttf", "Maki-Sans");
                    fonts.AddFont("MP Manga.ttf", "MP Manga Font");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton(AudioManager.Current);
            return builder.Build();
        }
    }
}
