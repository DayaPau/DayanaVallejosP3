using System.Collections.ObjectModel;
using DayanaVallejosP3.Models;
using DayanaVallejosP3.Servicios;

namespace DayanaVallejosP3.ViewModels
{
    public class AirportListViewModel : BaseViewModel
    {
        private readonly AeropuertoService _service;

        public ObservableCollection<Aeropuerto> Airports { get; set; }

        public AirportListViewModel()
        {
            _service = new AeropuertoService("https://freetestapi.com/api/v1/airports?search");
            Airports = new ObservableCollection<Aeropuerto>(_service.GetAllAirports());
        }
    }
}

