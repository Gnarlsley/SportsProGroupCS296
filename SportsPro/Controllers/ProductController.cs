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

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
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
        public ActionResult Edit(int id, Product updatedProduct)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(updatedProduct);
                }

                var product = _context.Products.Find(id);

                if (product == null)
                {
                    return View();
                }

                product.Name = updatedProduct.Name;
                product.YearlyPrice = updatedProduct.YearlyPrice;
                product.ReleaseDate = updatedProduct.ReleaseDate;

                _context.SaveChanges();

                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
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
