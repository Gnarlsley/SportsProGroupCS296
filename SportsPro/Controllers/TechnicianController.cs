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
        public IActionResult List()
        {
            var productsList = _context.Technicians.ToList();
            return View(productsList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Technician technician)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Technicians.Add(technician);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(List));
                }

                ViewBag.Action = "Add";
                return View("Edit", technician);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Action = "Add";
                return View(new Technician());
            }

            var technician = _context.Technicians.Find(id);
            if (technician == null)
            {
                return NotFound();
            }

            ViewBag.Action = "Edit";
            return View(technician);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                if (technician.TechnicianID == 0)
                {
                    _context.Technicians.Add(technician);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Technicians.Update(technician);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(List));
            }
            else
            {
                ViewBag.Action = (technician.TechnicianID == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteProd = _context.Technicians.Find(id);
            return View(deleteProd);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteProd = _context.Technicians.Find(id);

            if (deleteProd == null)
            {
                return NotFound();
            }

            _context.Technicians.Remove(deleteProd);

            _context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
