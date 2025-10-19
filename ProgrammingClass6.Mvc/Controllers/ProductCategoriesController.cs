using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
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
            List<ProductCategory> productCategories = _dbCotnext
                .ProductCategories
                .Include(productCategory => productCategory.Category)
                .Where(productCategory => productCategory.ProductId == productId)
                .ToList();

            var viewModel = new ProductCategoriesViewModels
            {
                ProductCategory = new ProductCategory
                {
                    ProductId = productId
                },

                ProductCategories = productCategories
            };

            return View(viewModel);    
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {        
            var productCategory = new ProductCategory();

            productCategory.ProductId = productId;

            var viewModel = new ProductCategoriesViewModels
            {             
                ProductCategories = _dbCotnext.ProductCategories.ToList()  
            }; 
            
            return View(viewModel);  
        }

        [HttpPost]
        public IActionResult Create(ProductCategoriesViewModels viewModel)
        {         
            _dbCotnext.ProductCategories.Add(viewModel.ProductCategory);
            _dbCotnext.SaveChanges();

            return RedirectToAction("Index", new { productId = viewModel.ProductCategory.ProductId });   
        }

        [HttpPost]
        public IActionResult Delete(int productId, int categoryId)     
        {
            var productCategory = _dbCotnext.ProductCategories
                .SingleOrDefault(productCategory => productCategory.ProductId == productId && productCategory.CategoryId == categoryId);

            _dbCotnext.Remove(productCategory);
            _dbCotnext.SaveChanges();

            return RedirectToAction("Index", new { productId = productCategory.ProductId });
        }
    }
}
