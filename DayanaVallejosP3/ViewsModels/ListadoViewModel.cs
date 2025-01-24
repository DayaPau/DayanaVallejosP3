using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DayanaVallejosP3.Models;
using DayanaVallejosP3.Servicios;

namespace DayanaVallejosP3.ViewsModels
{
    [ObservableObject]
    public partial class ListadoViewModel
    {
        private readonly DatabaseService _databaseService;

        public ListadoViewModel() { }

        public ListadoViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));
            Airports = new ObservableCollection<Aeropuerto>();
        }

        [ObservableProperty]
        private ObservableCollection<Aeropuerto> airports;

        [RelayCommand]
        private async Task LoadAirportsAsync()
        {
            try
            {
                var airportsFromDb = await _databaseService.GetAirportsAsync();
                if (airportsFromDb != null && airportsFromDb.Any())
                {
                    Airports.Clear();
                    foreach (var airport in airportsFromDb)
                    {
                        Airports.Add(airport);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontraron aeropuertos en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar los aeropuertos: {ex.Message}");
            }
        }
    }
}
