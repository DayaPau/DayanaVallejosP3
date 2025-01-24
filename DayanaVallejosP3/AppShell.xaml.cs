using DayanaVallejosP3.Views;
using DayanaVallejosP3.ViewsModels;

namespace DayanaVallejosP3;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Registrar rutas para navegación programática
        Routing.RegisterRoute(nameof(BusquedaViewModel), typeof(BusquedaViewModel));
        Routing.RegisterRoute(nameof(ListadoViewModel), typeof(ListadoViewModel));
    }
}

