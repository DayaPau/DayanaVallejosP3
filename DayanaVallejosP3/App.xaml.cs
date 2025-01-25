using DayanaVallejosP3.Views;

namespace DayanaVallejosP3;

public partial class App : Application
{
    public App(AeropuertoBuscador searchPage)
    {
        InitializeComponent();
        MainPage = new AppShell(searchPage);
    }
}

