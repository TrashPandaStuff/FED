using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
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
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddTransient<CalenderViewModel>();
        builder.Services.AddTransient<CalenderPage>();
        builder.Services.AddTransient<CreateOrderViewModel>();
        builder.Services.AddTransient<CreateOrderPage>();
        builder.Services.AddTransient<CreateInvoicePage>();
        builder.Services.AddTransient<CreateInvoiceViewModel>();
        builder.Services.AddTransient<SeeInvoicePage>();
        builder.Services.AddTransient<SeeInvoiceViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}