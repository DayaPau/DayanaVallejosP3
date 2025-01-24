using SQLite;
using System.Net.Http.Json;
using DayanaVallejosP3.Models;


namespace DayanaVallejosP3.Servicios
{
    public class AirportService
    {
        private readonly SQLiteConnection _database;

        public AirportService(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Aeropuerto>();
        }

        public async Task<Aeropuerto?> SearchAirportAsync(string country)
        {
            using var client = new HttpClient();
            var url = $"https://freetestapi.com/api/v1/airports?search={country}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<Airport>>();
                return data?.FirstOrDefault();
            }

            return null;
        }

        public void SaveAirport(Aeropuerto airport)
        {
            _database.Insert(airport);
        }

        public List<Aeropuerto> GetAllAirports()
        {
            return _database.Table<Aeropuerto>().ToList();
        }
    }   
}
