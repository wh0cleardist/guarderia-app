using System.Collections.Generic;

namespace GuarderiaApp.Models
{
    public class Plato
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
    }
}
