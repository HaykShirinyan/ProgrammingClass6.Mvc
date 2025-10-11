using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using ProgrammingClass6.Mvc.Data.Migrations;

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
            ViewBag.ProductId = productId;

            var productColors = _dbContext
                .ProductColors
                .Include(productColor => productColor.Color)    
                .Where(productColor => productColor.ProductId == productId)
                .ToList();

            return View(productColors);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var productColor = new ProductColor();

            productColor.ProductId = productId;

            ViewBag.Colors = _dbContext.Colors.ToList();

            return View(productColor);
        }

        [HttpPost]
        public IActionResult Create(ProductColor productColor)
        {
            _dbContext.ProductColors.Add(productColor);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = productColor.ProductId });
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
