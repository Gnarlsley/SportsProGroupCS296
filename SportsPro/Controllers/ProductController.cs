using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private readonly SportsProContext _context;
        // GET: ProductController
        
        public ProductController(SportsProContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            var productsList = _context.Products.ToList();
            return View(productsList);
        }

        // GET: ProductController/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: ProductController/Create
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

        // GET: ProductController/Edit/5
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

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
