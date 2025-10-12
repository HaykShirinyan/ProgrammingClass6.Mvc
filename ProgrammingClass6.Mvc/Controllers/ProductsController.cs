using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Products
        public IActionResult Index()
        {
            var products = _dbContext.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.ProductCategories)
                    .ThenInclude(pc => pc.Category)
                .ToList();

            return View(products);
        }

        // GET: Products/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public IActionResult Create(Product product, int[] selectedCategories)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();

                foreach (var catId in selectedCategories)
                {
                    _dbContext.ProductCategories.Add(new ProductCategory
                    {
                        ProductId = product.Id,
                        CategoryId = catId
                    });
                }
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View(product);
        }

        // GET: Products/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext.Products
                .Include(p => p.ProductCategories)
                .SingleOrDefault(p => p.Id == id);

            if (product == null) return NotFound();

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public IActionResult Edit(Product product, int[] selectedCategories)
        {
            if (ModelState.IsValid)
            {
                var existing = _dbContext.Products
                    .Include(p => p.ProductCategories)
                    .Single(p => p.Id == product.Id);

                existing.Name = product.Name;
                existing.Description = product.Description;
                existing.UnitPrice = product.UnitPrice;
                existing.Quantity = product.Quantity;
                existing.ManufacturerId = product.ManufacturerId;

                // Update categories
                existing.ProductCategories.Clear();
                foreach (var catId in selectedCategories)
                {
                    existing.ProductCategories.Add(new ProductCategory
                    {
                        ProductId = existing.Id,
                        CategoryId = catId
                    });
                }

                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();
            ViewBag.Categories = _dbContext.Categories.ToList();
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Products
                .Include(p => p.ProductCategories)
                .SingleOrDefault(p => p.Id == id);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
