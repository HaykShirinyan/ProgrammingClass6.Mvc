using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using Microsoft.EntityFrameworkCore;

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

            productColor.ColorId = productId;

            ViewBag.Color = _dbContext.Colors.ToList();

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
                .SingleOrDefault(ps => ps.ProductId == productId && ps.ColorId == colorId);


            if (productColor == null)
            {
                return NotFound();
            }
            _dbContext.ProductColors.Remove(productColor);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = productId });
        }


    }


}

