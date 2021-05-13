using System;
using System.ComponentModel.DataAnnotations;

namespace Active_Directory.Models
{
    public class Profesor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime Hora { get; set; }

    }
}