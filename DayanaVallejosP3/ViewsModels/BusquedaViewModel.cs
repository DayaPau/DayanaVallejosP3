using System;
using System.Windows.Input;
using DayanaVallejosP3.Servicios;
using DayanaVallejosP3.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DayanaVallejosP3.ViewsModels
{
    public partial class BusquedaViewModel : ObservableObject
    {
        private readonly AeropuertoService _service;

        [ObservableProperty]
        private string searchQuery;

        [ObservableProperty]
        private Aeropuerto foundAirport;

        [ObservableProperty]
        private string errorMessage;

        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }

        public BusquedaViewModel(AeropuertoService service)
        {
            _service = service;

            SearchCommand = new AsyncRelayCommand(SearchAirportAsync);
            ClearCommand = new RelayCommand(ClearSearch);
        }

        private async Task SearchAirportAsync()
        {
            try
            {
                ErrorMessage = string.Empty;

                if (string.IsNullOrWhiteSpace(SearchQuery))
                {
                    ErrorMessage = "Por favor, ingrese un país para buscar.";
                    return;
                }

                FoundAirport = await _service.SearchAirportAsync(SearchQuery);

                if (FoundAirport == null)
                {
                    ErrorMessage = "No se encontró ningún aeropuerto.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error al buscar el aeropuerto: {ex.Message}";
            }
        }

        private void ClearSearch()
        {
            SearchQuery = string.Empty;
            FoundAirport = null;
            ErrorMessage = string.Empty;
        }
    }
}


