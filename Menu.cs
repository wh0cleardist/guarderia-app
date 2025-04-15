using System.Collections.Generic;

namespace GuarderiaApp.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<Plato> Platos { get; set; } = new List<Plato>();
    }
}
