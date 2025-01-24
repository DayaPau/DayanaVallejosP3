using System.Collections.ObjectModel;
using DayanaVallejosP3.Models;
using DayanaVallejosP3.Servicios;

namespace DayanaVallejosP3.ViewsModels
{
    public class ListadoViewModel : BaseViewModel
    {
        private readonly AeropuertoService _service;

        private ObservableCollection<Aeropuerto> _airports;
        public ObservableCollection<Aeropuerto> Airports
        {
            get => _airports;
            set => SetProperty(ref _airports, value);
        }

        public ListadoViewModel()
        {
            _service = new AeropuertoService("ruta_base_datos_aqui"); // Asegúrate de pasar la ruta correcta
            LoadAirports();
        }

        private void LoadAirports()
        {
            var airportList = _service.GetAllAirports();
            Airports = new ObservableCollection<Aeropuerto>(airportList);
        }
    }
}


