using DayanaVallejosP3.Servicios;
using DayanaVallejosP3.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace DayanaVallejosP3.ViewsModels
{
    public class BusquedaViewModel : BindableObject
    {
        private readonly IDatabaseService _databaseService;
        private readonly AeropuertoService _apiService;
        private ObservableCollection<Aeropuerto> _aeropuertos;

        public ObservableCollection<Aeropuerto> Aeropuertos
        {
            get => _aeropuertos;
            set
            {
                _aeropuertos = value;
                OnPropertyChanged();
            }
        }

        public BusquedaViewModel()
        {
            _databaseService = DependencyService.Get<IDatabaseService>();
            _apiService = new AeropuertoService();
            Aeropuertos = new ObservableCollection<Aeropuerto>();
        }

        public async Task LoadAeropuertosAsync(string country)
        {
            var aeropuertos = await _databaseService.GetAeropuertosAsync();
            Aeropuertos.Clear();

            foreach (var aeropuerto in aeropuertos)
            {
                Aeropuertos.Add(aeropuerto);
            }

            var newAeropuerto = await _apiService.GetAeropuertoFromApiAsync(country);
            await _databaseService.SaveAeropuertoAsync(newAeropuerto);
            Aeropuertos.Add(newAeropuerto);
        }


    }
}






