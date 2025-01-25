using Microsoft.Maui.Controls;
using DayanaVallejosP3.ViewsModels;

namespace DayanaVallejosP3.Views
{
    public partial class Listado : ContentPage
    {
        private readonly ListadoViewModel _viewModel;

        public Listado(ListadoViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadAeropuertosAsync(); 
        }
    }
}

