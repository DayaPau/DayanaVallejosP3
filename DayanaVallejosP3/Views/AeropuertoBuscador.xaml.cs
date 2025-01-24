using DayanaVallejosP3.ViewsModels;

namespace DayanaVallejosP3.Views
{
    public partial class AeropuertoBuscador : ContentPage
    {
        public AeropuertoBuscador()
        {
            InitializeComponent();
            BindingContext = new BusquedaViewModel();
        }
    }
}
