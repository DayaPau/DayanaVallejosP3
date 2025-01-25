using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Argon;
using DayanaVallejosP3.Models;
using SQLite;

namespace DayanaVallejosP3.Servicios
{
    public class AeropuertoService
    {
        private readonly HttpClient _httpClient;

        public AeropuertoService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Aeropuerto> GetAeropuertoFromApiAsync(string country)
        {
            var url = $"https://freetestapi.com/api/v1/airports?search={country}";
            var response = await _httpClient.GetStringAsync(url);
            var aeropuerto = JsonConvert.DeserializeObject<Aeropuerto>(response);
            return aeropuerto;
        }
    }
}

