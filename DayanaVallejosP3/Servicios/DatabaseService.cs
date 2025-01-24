using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using DayanaVallejosP3.Models;

namespace DayanaVallejosP3.Servicios
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            // Configura la base de datos SQLite.
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Aeropuertos.db");
            _database = new SQLiteAsyncConnection(dbPath);

            // Crea la tabla de Aeropuertos si no existe.
            _database.CreateTableAsync<Aeropuerto>().Wait();
        }

        
        public async Task SaveAirportAsync(Aeropuerto aeropuerto)
        {
            if (aeropuerto != null)
            {
                await _database.InsertAsync(aeropuerto);
            }
        }

        
        public async Task<List<Aeropuerto>> GetAirportsAsync()
        {
            return await _database.Table<Aeropuerto>().ToListAsync();
        }

      
        public async Task DeleteAirportAsync(Aeropuerto aeropuerto)
        {
            if (aeropuerto != null)
            {
                await _database.DeleteAsync(aeropuerto);
            }
        }

        public async Task ClearAirportsAsync()
        {
            await _database.DeleteAllAsync<Aeropuerto>();
        }
    }
}
