using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProgrammingClass6.Mvc.ViewModels;

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
            var viewModel = new ProductViewModel
            {
                Manufacturers = _dbContext.Manufacturers.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(viewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            viewModel.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(viewModel);
        }

        // /products/edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _dbContext
                .Products
                .SingleOrDefault(dbProductRow => dbProductRow.Id == id);

            var viewModel = new ProductViewModel
            {
                Product = product,
                Manufacturers = _dbContext.Manufacturers.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(viewModel.Product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            viewModel.Manufacturers = _dbContext.Manufacturers.ToList();

            return View(viewModel);
        }
    }
}
