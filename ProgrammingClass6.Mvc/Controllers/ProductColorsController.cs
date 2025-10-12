using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductColorsController : Controller
    {
        private ApplicationDbContext _dbCotnext;

        public ProductColorsController(ApplicationDbContext dbCotnext)
        {
            _dbCotnext = dbCotnext;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            ViewBag.ProductId = productId;

            var productColors = _dbCotnext
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

            ViewBag.Colors = _dbCotnext.Colors.ToList();

            return View(productColor);
        }

        [HttpPost]
        public IActionResult Create(ProductColor productColor)
        {
            _dbCotnext.ProductColors.Add(productColor);
            _dbCotnext.SaveChanges();

            return RedirectToAction("Index", new { productId = productColor.ProductId });
        }

        [HttpPost]
        public IActionResult Delete(int productId, int colorId)
        {
            var productColor = _dbCotnext
                .ProductColors
                .SingleOrDefault(productColor => productColor.ProductId == productId && productColor.ColorId == colorId);

            _dbCotnext.Remove(productColor);
            _dbCotnext.SaveChanges();

            return RedirectToAction("Index", new { productId = productColor.ProductId });
        }
    }
}
