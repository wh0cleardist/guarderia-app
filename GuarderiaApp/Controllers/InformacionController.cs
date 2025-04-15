using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuarderiaApp.Controllers
{
    public class InformacionController : Controller
    {
        // GET: InformacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InformacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InformacionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InformacionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InformacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InformacionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InformacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InformacionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}