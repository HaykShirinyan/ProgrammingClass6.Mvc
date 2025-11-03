using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using System.Security.Claims;
using ProgrammingClass6.Mvc.ViewModels;

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
            var ViewModel = new ProductCategoryViewModel
            {
                ProductCategory = new ProductCategory { ProductId = productId },
                Categories = _dbCotnext.Categories.ToList(),
                ProductCategories = _dbCotnext.ProductCategories
                .Include(pc => pc.Category)
                .Where(pc => pc.ProductId == productId)
                .ToList()
            };

            return View(ViewModel);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var productCategory = new ProductCategory();

            productCategory.ProductId = productId;

            var viewModel = new ProductCategoryViewModel
            {
                ProductCategory = productCategory,
                Categories = _dbCotnext.Categories.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductCategoryViewModel viewModel)
        {
            _dbCotnext.ProductCategories.Add(viewModel.ProductCategory);
            _dbCotnext.SaveChanges();

            return RedirectToAction("Index", new { productId = viewModel.ProductCategory.ProductId });
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
