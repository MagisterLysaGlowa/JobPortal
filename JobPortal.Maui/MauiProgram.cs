using JobPortal.Maui.Pages;
using JobPortal.Maui.ViewModels;
using Microsoft.Extensions.Logging;

namespace JobPortal.Maui
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
            builder.Services.AddSingleton<WelcomePage>();
            builder.Services.AddSingleton<WelcomePageViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<RegisterPageViewModel>();
#if DEBUG
                builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}