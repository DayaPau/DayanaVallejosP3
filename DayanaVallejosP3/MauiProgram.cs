using DayanaVallejosP3;
using DayanaVallejosP3.Views;
using DayanaVallejosP3.ViewsModels;

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

        
        builder.Services.AddSingleton<AeropuertoBuscador>();
        builder.Services.AddSingleton<Listado>();
        builder.Services.AddSingleton<BusquedaViewModel>();
        builder.Services.AddSingleton<ListadoViewModel>();

        return builder.Build();
    }
}


