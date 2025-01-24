using System;
using System.ComponentModel;
using System.Windows.Input;
using DayanaVallejosP3.Servicios;
using DayanaVallejosP3.Models;
using CommunityToolkit.Mvvm.Input;

namespace DayanaVallejosP3.ViewsModels
{
    public class BusquedaViewModel : INotifyPropertyChanged
    {
        private readonly AeropuertoService _aeropuertoService;
        private string _searchText;
        private Aeropuerto _foundAirport;

        public event PropertyChangedEventHandler PropertyChanged;

        public BusquedaViewModel(AeropuertoService aeropuertoService)
        {
            _aeropuertoService = aeropuertoService ?? throw new ArgumentNullException(nameof(aeropuertoService));
            SearchCommand = new AsyncRelayCommand(SearchAirportAsync);
            ClearCommand = new RelayCommand(ClearSearch);
        }

       
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }

       
        public Aeropuerto FoundAirport
        {
            get => _foundAirport;
            set
            {
                if (_foundAirport != value)
                {
                    _foundAirport = value;
                    OnPropertyChanged(nameof(FoundAirport));
                }
            }
        }

      
        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }

        
        private async Task SearchAirportAsync()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Console.WriteLine("Por favor, ingresa un país válido.");
                return;
            }

            try
            {
                var aeropuerto = await _aeropuertoService.SearchAirportAsync(SearchText);
                if (aeropuerto != null)
                {
                    FoundAirport = aeropuerto;
                    Console.WriteLine("Aeropuerto encontrado exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró ningún aeropuerto para el país ingresado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar el aeropuerto: {ex.Message}");
            }
        }

        
        private void ClearSearch()
        {
            SearchText = string.Empty;
            FoundAirport = null;
        }

        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}






