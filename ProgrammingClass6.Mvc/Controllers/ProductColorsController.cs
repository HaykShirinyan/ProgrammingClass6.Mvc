using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Models;

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
            ViewBag.ProductId = productId;
            var productColors = _dbContext
                .ProductColors
                .Include(pc => pc.Color)
                .Where(pc => pc.ProductId == productId)
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
            if (ModelState.IsValid)
            {
                _dbContext.ProductColors.Add(productColor);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", new { productId = productColor.ProductId });
            }
            ViewBag.Colors = _dbContext.Colors.ToList();
            return View(productColor);
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
            return RedirectToAction("Index", new { productId = productId });
        }

    }
}
