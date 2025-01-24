using System.Windows.Input;
using DayanaVallejosP3.Models;
using DayanaVallejosP3.Servicios;

namespace DayanaVallejosP3.ViewsModels
{
    public class BusquedaViewModel : BaseViewModel
    {
        private readonly AeropuertoService _service;
        public string Country { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }

        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }

        public BusquedaViewModel()
        {
            _service = new AeropuertoService("database_path_here");
            SearchCommand = new Command(async () => await SearchAirport());
            ClearCommand = new Command(() => Country = string.Empty);
        }

        private async Task SearchAirport()
        {
            var airport = await _service.SearchAirportAsync(Country);
            if (airport != null)
            {
                airport.SCordova = "DVallejos"; 
                _service.SaveAirport(airport);
                Message = "¡Aeropuerto encontrado y guardado!";
                IsError = false;
            }
            else
            {
                Message = "No se encontró ningún aeropuerto.";
                IsError = true;
            }
        }
    }
}

