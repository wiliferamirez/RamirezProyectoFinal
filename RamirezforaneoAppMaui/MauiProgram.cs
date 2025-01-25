using Microsoft.Extensions.Logging;
using RamirezforaneoAppMaui.Models.Authentication;
using RamirezforaneoAppMaui.Services;
using RamirezforaneoAppMaui.ViewModel.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace RamirezforaneoAppMaui
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

            builder.Services.AddSingleton<AuthenticationService>(provider =>
            new AuthenticationService(new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7242/")
        }));
            builder.Services.AddTransient<Login>(); 
            builder.Services.AddTransient<LoginViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
