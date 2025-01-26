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

            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<Register>();
            builder.Services.AddTransient<Login>(); 
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddSingleton<AuthenticationService>();
            builder.Services.AddTransient<RegisterViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
