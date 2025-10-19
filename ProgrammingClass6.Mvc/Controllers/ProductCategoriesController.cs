using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using ProgrammingClass6.Mvc.ViewModels;
using System.Linq;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductCategoriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            var productCategories = _dbContext
                .ProductCategories
                .Include(productCategory => productCategory.Category)
                .Where(productCategory => productCategory.ProductId == productId)
                .ToList();

            var viewModel = new CategoriesViewModel
            {
                Product = _dbContext.Products.Find(productId),
                Categories = productCategories.Select(pc => pc.Category).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var viewModel = new CategoriesViewModel
            {
                Product = _dbContext.Products.Find(productId),
                Categories = _dbContext.Categories.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(int productId, int selectedCategoryId)
        {
            var productCategory = new ProductCategory
            {
                ProductId = productId,
                CategoryId = selectedCategoryId
            };

            _dbContext.ProductCategories.Add(productCategory);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId });
        }


        [HttpPost]
        public IActionResult Delete(int productId, int categoryId)
        {
            var productCategory = _dbContext
                .ProductCategories
                .SingleOrDefault(pc => pc.ProductId == productId && pc.CategoryId == categoryId);

            _dbContext.ProductCategories.Remove(productCategory);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = productCategory.ProductId });
        }
    }
}
