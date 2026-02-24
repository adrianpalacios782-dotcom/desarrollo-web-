using System;

namespace TechApp.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Equipo()
        {
            Nombre = string.Empty;
            Marca = string.Empty;
        }
    }
}
