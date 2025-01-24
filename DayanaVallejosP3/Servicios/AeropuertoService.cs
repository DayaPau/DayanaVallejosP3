using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DayanaVallejosP3.Models;
using SQLite;

namespace DayanaVallejosP3.Servicios
{
    public class AeropuertoService
    {
        private readonly HttpClient _httpClient;
        private readonly SQLiteConnection _database;

        public AeropuertoService(string dbPath)
        {
          
            _httpClient = new HttpClient();

            
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Aeropuerto>();    
        }


        public async Task<Aeropuerto> SearchAirportAsync(string query)
        {
            try
            {
                string url = $"https://freetestapi.com/api/v1/airports?search={query}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error en la API: {response.StatusCode}");
                    return null;
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Respuesta JSON: {jsonResponse}");

                var airports = JsonSerializer.Deserialize<List<AeropuertoResponse>>(jsonResponse);

                if (airports == null || airports.Count == 0)
                {
                    Console.WriteLine("No se encontraron aeropuertos.");
                    return null;
                }

                var airport = airports[0];

                // Crear el objeto
                var aeropuerto = new Aeropuerto
                {
                    Name = airport.name,
                    Country = airport.country,
                    Latitude = airport.latitude,
                    Longitude = airport.longitude,
                    Email = airport.email,
                    DVallejos = "SCordova" 
                };

                
                SaveAirport(aeropuerto);

                return aeropuerto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en SearchAirportAsync: {ex.Message}");
                return null;
            }
        }

   
        private void SaveAirport(Aeropuerto aeropuerto)
        {
            try
            {
                // Evitar duplicados basados en el nombre
                var existing = _database.Table<Aeropuerto>().FirstOrDefault(a => a.Name== aeropuerto.Name);

                if (existing == null)
                {
                    _database.Insert(aeropuerto);
                    Console.WriteLine("Aeropuerto guardado en la base de datos.");
                }
                else
                {
                    Console.WriteLine("El aeropuerto ya existe en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el aeropuerto: {ex.Message}");
            }
        }

    
        public List<Aeropuerto> GetAllAirports()
        {
            try
            {
                return _database.Table<Aeropuerto>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener aeropuertos: {ex.Message}");
                return new List<Aeropuerto>();
            }
        }
    }


    public class AeropuertoResponse
    {
        public string name { get; set; }
        public string country { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string email { get; set; }
    }
}

