using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductCategoriesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            ViewBag.ProductId = productId;

            var productCategories = _dbContext
                .ProductCategories
                .Include(productCategory => productCategory.Category)
                .Where(productCategory => productCategory.ProductId == productId)
                .ToList();

            return View(productCategories);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var productCategory = new ProductCategory();

            productCategory.ProductId = productId;

            ViewBag.Categories = _dbContext.Categories.ToList();

            return View(productCategory);
        }

        [HttpPost]
        public IActionResult Create(ProductCategory productCategory)
        {
            _dbContext.ProductCategories.Add(productCategory);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = productCategory.ProductId });
        }

        [HttpPost]
        public IActionResult Delete(int productId, int categoryId)
        {
            var productCategory = _dbContext
                .ProductCategories
                .SingleOrDefault(productCategory => productCategory.ProductId == productId && productCategory.CategoryId == categoryId);

            if (productCategory == null)
            {
                return NotFound();
            }

            _dbContext.Remove(productCategory);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = productCategory.ProductId });
        }

    }



}

