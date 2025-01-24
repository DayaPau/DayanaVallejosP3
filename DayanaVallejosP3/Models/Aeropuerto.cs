﻿using SQLite;

namespace YourNamespace.Models
{
    public class Aeropuerto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Email { get; set; }
        public string DVallejos { get; set; } 
    }
}


