using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechnicianController : Controller
    {
        private readonly SportsProContext _context;

        public TechnicianController(SportsProContext context)
        {
            _context = context;
        }
        // GET: TechnicianController
        public ActionResult List()
        {
            var TechnicianList = _context.Technicians;
            return View(TechnicianList);
        }

        // GET: TechnicianController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TechnicianController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnicianController/Create
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

        // GET: TechnicianController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TechnicianController/Edit/5
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

        // GET: TechnicianController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TechnicianController/Delete/5
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
