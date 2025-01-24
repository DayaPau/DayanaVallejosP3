using DayanaVallejosP3.Views;
using DayanaVallejosP3.ViewsModels;

namespace DayanaVallejosP3
{
    public partial class App : Application
    {
        public App(BusquedaViewModel searchPage)
        {
            InitializeComponent();
            MainPage = new AppShell(searchPage);
        }
    }
}
