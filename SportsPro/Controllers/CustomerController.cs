using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SportsProContext _context;

        public CustomerController(SportsProContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            var customersList = _context.Customers.ToList();
            return View(customersList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Customer());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return View();
            }
            else
            {
                return View(customer);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerID == 0)
                {
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Customers.Update(customer);
                    _context.SaveChanges();
                }
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = (customer.CustomerID == 0) ? "Add" : "Edit";
                return View(customer);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteProd = _context.Customers.Find(id);
            return View(deleteProd);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteCust = _context.Customers.Find(id);

            if (deleteCust == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(deleteCust);

            _context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
