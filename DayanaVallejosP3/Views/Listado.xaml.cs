using DayanaVallejosP3.ViewsModels;

namespace DayanaVallejosP3.Views
{
    public partial class Listado : ContentPage
    {
        public Listado()
        {
            InitializeComponent();
            BindingContext = new ListadoViewModel(new Servicios.DatabaseService()); // Asegúrate de pasar la dependencia
        }

        public Listado(ListadoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
