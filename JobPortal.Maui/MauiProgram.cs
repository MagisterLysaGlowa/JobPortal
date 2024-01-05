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
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<RegisterPageViewModel>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomePageViewModel>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<ProfilePageViewModel>();
            builder.Services.AddSingleton<JobOfertPage>();
            builder.Services.AddSingleton<JobOfertPageViewModel>();
            builder.Services.AddSingleton<OfertDetailsPage>();
            builder.Services.AddSingleton<OfertDetailsPageViewModel>();
            builder.Services.AddSingleton<JobOfertApplicationDetailsPage>();
            builder.Services.AddSingleton<JobOfertApplicationDetailsPageViewModel>();
            builder.Services.AddSingleton<CurrentApplicationsPage>();
            builder.Services.AddSingleton<CurrentApplicationsViewModel>();
            builder.Services.AddSingleton<FavouriteOfertsPage>();
            builder.Services.AddSingleton<FavouriteOfertsPageViewModel>();
            builder.Services.AddSingleton<LogoutPage>();
            builder.Services.AddSingleton<LogoutPageViewModel>();
            builder.Services.AddSingleton<EditJobOfertPage>();
            builder.Services.AddSingleton<EditJobOfertPageViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}