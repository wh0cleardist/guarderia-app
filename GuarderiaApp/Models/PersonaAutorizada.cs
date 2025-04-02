using System.Collections.Generic;
using GuarderiaApp.Models;

namespace GuarderiaApp.Models
{
    public class PersonaAutorizada
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Relacion { get; set; } = string.Empty;  // Ejemplo: Madre, Padre, Tío, etc.

        public List<Niño> Niños { get; set; } = new List<Niño>();
    }
}
