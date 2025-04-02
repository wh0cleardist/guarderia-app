using System;
using GuarderiaApp.Models;

namespace GuarderiaApp.Models
{
    public class MenuConsumido
    {
        public int Id { get; set; } 
        public int NiñoId { get; set; }
        public Niño Niño { get; set; } = new Niño();
        public int MenuId { get; set; }  
        public Menu Menu { get; set; } = new Menu();
        public DateTime Fecha { get; set; } = new DateTime();
    }
}
