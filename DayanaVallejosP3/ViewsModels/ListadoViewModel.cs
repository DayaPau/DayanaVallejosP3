using System.Collections.ObjectModel;
using DayanaVallejosP3.Models;
using DayanaVallejosP3.Servicios;

namespace YourNamespace.ViewModels
{
    public class AirportListViewModel : BaseViewModel
    {
        private readonly AirportService _service;

        public ObservableCollection<Airport> Airports { get; set; }

        public AirportListViewModel()
        {
            _service = new AirportService("");
            Airports = new ObservableCollection<Airport>(_service.GetAllAirports());
        }
    }
}

