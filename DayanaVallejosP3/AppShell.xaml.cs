using DayanaVallejosP3.Views;
using DayanaVallejosP3.ViewsModels;

namespace DayanaVallejosP3
{
    public partial class AppShell : Shell
    {
        public AppShell(AeropuertoBuscador searchPage)
        {
            InitializeComponent();


            Items.Add(new ShellContent
            {
                Title = "Buscar",
                Content = searchPage
            });
        }

    }
}

