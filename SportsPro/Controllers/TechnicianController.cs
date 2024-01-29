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
            var technicianList = _context.Technicians.ToList();
            return View(technicianList);
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
            var technician = _context.Technicians.Find(id);
            if (technician == null)
            {
                return View();
            }
            else
            {
                return View(technician);
            }
        }

        // POST: TechnicianController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Technician updatedTechnician)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(updatedTechnician);
                }

                var technician = _context.Technicians.Find(id);

                if (technician == null)
                {
                    return View();
                }

                technician.Name = updatedTechnician.Name;
                technician.Email = updatedTechnician.Email;
                technician.Phone = updatedTechnician.Phone;

                _context.SaveChanges();

                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
        // GET: ProductController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteTech = _context.Technicians.Find(id);
            return View(deleteTech);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteTech = _context.Technicians.Find(id);

            if (deleteTech == null)
            {
                return NotFound();
            }

            _context.Technicians.Remove(deleteTech);

            _context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
