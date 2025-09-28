using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private ApplicationDbContext _dbCotnext;

        public ProductCategoriesController(ApplicationDbContext dbCotnext)
        {
            _dbCotnext = dbCotnext; 
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            ViewBag.ProductId = productId;

            var productCategories = _dbCotnext
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

            ViewBag.Categories = _dbCotnext.Categories.ToList();

            return View(productCategory);
        }

        [HttpPost]
        public IActionResult Create(ProductCategory productCategory)
        {
            _dbCotnext.ProductCategories.Add(productCategory);
            _dbCotnext.SaveChanges();

            return RedirectToAction("Index", new { productId = productCategory.ProductId });
        }

        [HttpPost]
        public IActionResult Delete(int productId, int categoryId)
        {
            var productCategory = _dbCotnext
                .ProductCategories
                .SingleOrDefault(productCategory => productCategory.ProductId == productId && productCategory.CategoryId == categoryId);

            _dbCotnext.Remove(productCategory);
            _dbCotnext.SaveChanges();

            return RedirectToAction("Index", new { productId = productCategory.ProductId });
        }
    }
}
