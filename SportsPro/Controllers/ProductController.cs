using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System;
using System.Linq;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(List));
                }

                ViewBag.Action = "Add";
                return View("Edit", product);
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
                return View(new Product());
            }

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Action = "Edit";
            return View(product);
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

                product.ProductCode = updatedProduct.ProductCode;
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
