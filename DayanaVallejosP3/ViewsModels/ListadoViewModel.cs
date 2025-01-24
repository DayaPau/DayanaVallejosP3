using System.Collections.ObjectModel;
using DayanaVallejosP3.Servicios;
using DayanaVallejosP3.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DayanaVallejosP3.ViewsModels
{
    public partial class ListadoViewModel : ObservableObject
    {
        private readonly AeropuertoService _service;

        [ObservableProperty]
        private ObservableCollection<Aeropuerto> airports;

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
