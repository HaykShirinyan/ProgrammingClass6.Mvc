using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;


namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductTypeColorsController : Controller
    {
        private ApplicationDbContext dbContext;
        public ProductTypeColorsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index(int productTypeId)
        {
            ViewBag.ProductTypeId = productTypeId;

            var productTypeColors = dbContext
                .ProductTypeColors
                .Include(ptc => ptc.Color)
                .Where(ptc => ptc.ProductTypeId == productTypeId)
                .ToList();
            return View(productTypeColors);
        }
        [HttpGet]
        public IActionResult Create(int productTypeId)
        {
            ViewBag.ProductTypeId = productTypeId;
            ViewBag.Colors = dbContext.Colors.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductTypeColor productTypeColor)
        {

                dbContext.ProductTypeColors.Add(productTypeColor);
                dbContext.SaveChanges();
                return RedirectToAction("Index", new { productTypeId = productTypeColor.ProductTypeId });

        }
        [HttpPost]
        public IActionResult Delete(int productTypeId, int colorId)
        {
            var productTypeColor = dbContext.ProductTypeColors
                .SingleOrDefault(ptc => ptc.ProductTypeId == productTypeId && ptc.ColorId == colorId);

            if (productTypeColor != null)
            {
                dbContext.ProductTypeColors.Remove(productTypeColor);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index", new { productTypeId });
        }
    }
}
