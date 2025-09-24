using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _dbContext
                .Products
                .Include(product => product.Manufacturer)
                .ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

            return View();
        }

        // /products/edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext
                .Products
                .SingleOrDefault(dbProductRow => dbProductRow.Id == id);

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(product);
        }
    }
}
