using Microsoft.Extensions.Logging;
#if ANDROID
using Microsoft.Maui.Platform;
#endif
namespace Organizacion
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
                    fonts.AddFont("Elegant Bloom.otf", "Elegant Bloom");
                });
#if ANDROID
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), static (handler, view) =>
            {
                var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;
                if (activity?.Window != null)
                {
                    activity.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#E7C0FF"));
                }
            });

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("No_Borde", (handler, view) =>
            {
                handler.PlatformView.Background = null;
            });
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
