using DayanaVallejosP3.ViewsModels;

namespace DayanaVallejosP3.Views
{
    public partial class Listado : ContentPage
    {
        public Listado()
        {
            InitializeComponent();
     
        }

        public Listado(ListadoViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
