using System.Collections.ObjectModel;
using DayanaVallejosP3.Servicios;
using DayanaVallejosP3.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DayanaVallejosP3.ViewsModels
{
    public partial class ListadoViewModel : ObservableObject
    {
        private readonly DatabaseService _databaseService;

        [ObservableProperty]
        private ObservableCollection<Aeropuerto> airports;

        public ListadoViewModel()
        {
            // Constructor sin parámetros requerido para XAML
            _databaseService = new DatabaseService(); 
        }

        public ListadoViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public ListadoViewModel(AeropuertoService service)
        {
            _service = service;
            LoadAirports();
        }

        private void LoadAirports()
        {
            var airportList = _service.GetAllAirports();
            airports = new ObservableCollection<Aeropuerto>(airportList);
        }
    }
}
