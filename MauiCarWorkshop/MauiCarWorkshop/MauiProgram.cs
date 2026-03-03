using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MauiCarWorkshop.Services;
using MauiCarWorkshop.ViewModels;
using MauiCarWorkshop.Services;
using MauiCarWorkshop.ViewModels;
using MauiCarWorkshop.Views;

namespace MauiCarWorkshop;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<DataBaseService>();
        builder.Services.AddTransient<CalenderViewModel>();
        builder.Services.AddTransient<CalenderPage>();
        builder.Services.AddTransient<CreateOrderViewModel>();
        builder.Services.AddTransient<CreateOrderPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}