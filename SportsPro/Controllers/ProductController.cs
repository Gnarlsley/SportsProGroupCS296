using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private readonly SportsProContext _context;
        
        public ProductController(SportsProContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            var productsList = _context.Products.ToList();
            return View(productsList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return View();
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Products.Update(product);
                    _context.SaveChanges();
                }
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = (product.ProductID == 0) ? "Add" : "Edit";
                return View(product);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteProd = _context.Products.Find(id);
            return View(deleteProd);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteProd = _context.Products.Find(id);

            if (deleteProd == null)
            {
                return NotFound();
            }

           _context.Products.Remove(deleteProd);
            
            _context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
