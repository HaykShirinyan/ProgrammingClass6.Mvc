using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using ProgrammingClass6.Mvc.Data.Migrations;
using ProgrammingClass6.Mvc.ViewModels;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductColorsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            List<ProductColor> productColors = _dbContext
                .ProductColors
                .Include(productColor => productColor.Color)    
                .Where(productColor => productColor.ProductId == productId)
                .ToList();

            var viewModel = new ProductColorsViewModels
            {
                ProductColor = new ProductColor
                {
                    ProductId = productId
                },

                ProductColors = productColors
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var productColor = new ProductColor();

            productColor.ProductId = productId;

            var viewModel = new ProductColorsViewModels
            {                
                ProductColors = _dbContext.ProductColors.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductColorsViewModels viewModel)
        {
            _dbContext.ProductColors.Add(viewModel.ProductColor);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = viewModel.ProductColor.ProductId });
        }

        [HttpPost]
        public IActionResult Delete(int productId, int colorId)
        {
            var productColor = _dbContext
                .ProductColors
                .SingleOrDefault(productColor => productColor.ProductId == productId && productColor.ColorId == colorId);

            _dbContext.Remove(productColor);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = productColor.ProductId });
        }
    }
}
