using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DayanaVallejosP3.Models;

namespace DayanaVallejosP3.Servicios
{
    public class DatabaseService : IDatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "aeropuertos.db3");
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Aeropuerto>().Wait();
        }

        public Task SaveAeropuertoAsync(Aeropuerto aeropuerto)
        {
            return _database.InsertAsync(aeropuerto);
        }

        public Task<List<Aeropuerto>> GetAeropuertosAsync()
        {
            return _database.Table<Aeropuerto>().ToListAsync();
        }
    }


}

