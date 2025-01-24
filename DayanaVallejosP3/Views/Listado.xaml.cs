using DayanaVallejosP3.ViewsModels;

namespace DayanaVallejosP3.Views
{
    public partial class Listado : ContentPage
    {
        public Listado()
        {
            InitializeComponent();
            BindingContext = new ListadoViewModel();
        }
    }
}
