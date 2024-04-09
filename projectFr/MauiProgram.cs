using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using projectFr.Screnns;
using UraniumUI;

namespace projectFr
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
                .UseUraniumUIMaterial() // 👈 Don't forget these two lines.

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
            .UseMauiCompatibility()
            .ConfigureMauiHandlers((handlers) =>
            {
#if ANDROID
    handlers.AddCompatibilityRenderer(typeof(WebView), typeof(Platforms.Android.Renderers.UserAgentWebViewRenderer));
#endif
            })
    .ConfigureMauiHandlers(x =>
    {
#if ANDROID
        x.AddHandler<WebView, Platforms.Android.Controls.AndroidWebViewHandler>();

#endif
    });
            Routing.RegisterRoute("/Setting",typeof(SettingsPage));
            Routing.RegisterRoute("/Dashbord", typeof(HomePage));


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
