using DayanaVallejosP3.Servicios;

namespace DayanaVallejosP3
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

            // Configurar la ruta de la base de datos SQLite
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "airports.db");

            // Registrar servicios
            builder.Services.AddSingleton<AeropuertoService>(s => new AeropuertoService(databasePath));

            // Registrar ViewModels
            builder.Services.AddTransient<AirportListViewModel>();

            return builder.Build();
        }
    }
}

