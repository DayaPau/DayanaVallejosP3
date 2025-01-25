using System;
using System.Collections.ObjectModel;
using DayanaVallejosP3.Models;
using DayanaVallejosP3.Servicios;
using DayanaVallejosP3.ViewModels;

namespace DayanaVallejosP3.ViewsModels
{
    public partial class ListadoViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;
        private ObservableCollection<Aeropuerto> _aeropuertos;

        public ObservableCollection<Aeropuerto> Aeropuertos
        {
            get => _aeropuertos;
            set => SetProperty(ref _aeropuertos, value);
        }

        public ListadoViewModel()
        {
            _databaseService = new DatabaseService(); // Asegúrate de que el servicio de base de datos esté configurado correctamente.
            Aeropuertos = new ObservableCollection<Aeropuerto>();
        }

        // Método que carga los aeropuertos desde la base de datos.
        public async Task LoadAeropuertosAsync()
        {
            var aeropuertosList = await _databaseService.GetAeropuertosAsync(); // Llama al servicio de base de datos para obtener los aeropuertos.

            // Limpiar la lista y agregar los nuevos aeropuertos.
            Aeropuertos.Clear();
            foreach (var aeropuerto in aeropuertosList)
            {
                Aeropuertos.Add(aeropuerto);
            }
        }
    }
}
