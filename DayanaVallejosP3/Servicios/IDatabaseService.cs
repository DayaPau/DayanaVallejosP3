using System.Collections.Generic;
using System.Threading.Tasks;
using DayanaVallejosP3.Models;

namespace DayanaVallejosP3.Servicios
{
    public interface IDatabaseService
    {
        Task SaveAeropuertoAsync(Aeropuerto aeropuerto);
        Task<List<Aeropuerto>> GetAeropuertosAsync();
    }
}
