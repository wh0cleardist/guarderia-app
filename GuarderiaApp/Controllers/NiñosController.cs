using GuarderiaApp.Data;
using GuarderiaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuarderiaApp.Controllers
{
    public class NiñosController : Controller
    {
        private readonly GuarderiaDbContext _context;

        public NiñosController(GuarderiaDbContext context)
        {
            _context = context;
        }

        // Acción para listar los niños
        public async Task<IActionResult> Index()
        {
            var niños = await _context.Niños.ToListAsync();
            return View(niños);
        }

        // Acción para mostrar el formulario de creación
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar la creación de un niño
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Niño niño)
        {
            if (ModelState.IsValid)
            {
                _context.Add(niño);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(niño);
        }
    }
}
