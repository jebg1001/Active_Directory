using System;
using System.ComponentModel.DataAnnotations;

namespace Active_Directory.Models
{
    public class Alumno
    {
        public int ID { get; set; }
        public DateTime Hora { get; set; }
        public double Var1 { get; set; }
        public double Var2 { get; set; }
    }
}