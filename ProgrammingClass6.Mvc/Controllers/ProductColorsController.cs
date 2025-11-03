using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Data.Migrations;
using ProgrammingClass6.Mvc.Models;
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
        public IActionResult Index(int productId)
        {
            var ViewModel = new ProductColorViewModel
            {
                 
               ProductColor = new ProductColor { ProductId = productId },
               Colors = _dbContext.Colors.ToList(),
               ProductColors = _dbContext.ProductColors
               .Include(pc => pc.Color)
               .Where(pc => pc.ProductId == productId)
               .ToList()
            };

            return View(ViewModel);
        }
        [HttpGet]
        public IActionResult Create(int productId)
        {
            var productColor = new ProductColor();
            productColor.ProductId = productId;
            var viewModel= new ProductColorViewModel
            {
                ProductColor = productColor,
                Colors = _dbContext.Colors.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(ProductColorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ProductColors.Add(viewModel.ProductColor);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", new { productId = viewModel.ProductColor.ProductId });
            }
            viewModel.Colors = _dbContext.Colors.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Delete(int productId, int colorId)
        {
            var productColor = _dbContext
                .ProductColors
                .SingleOrDefault(pc => pc.ProductId == productId && pc.ColorId == colorId);
            if (productColor != null)
            {
                _dbContext.ProductColors.Remove(productColor);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index", new { productId });
        }

    }
}
