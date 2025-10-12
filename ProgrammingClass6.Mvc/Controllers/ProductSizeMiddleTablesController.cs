using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductSizeMiddleTablesController : Controller
    {
        private ApplicationDbContext _dbCotnext;

        public ProductSizeMiddleTablesController(ApplicationDbContext dbCotnext)
        {
            _dbCotnext = dbCotnext;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            ViewBag.ProductId = productId;

            var productSizes = _dbCotnext
                .ProductSizeMiddleTables
                .Include(productSize => productSize.ProductSize)
                .Where(productSize => productSize.ProductId == productId)
                .ToList();

            return View(productSizes);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var productSize = new ProductSizeMiddleTable();

            productSize.ProductId = productId;

            ViewBag.ProductSizes = _dbCotnext.ProductSizes.ToList();

            return View(productSize);
        }

        [HttpPost]
        public IActionResult Create(ProductSizeMiddleTable productSizeMiddleTable)
        {
            _dbCotnext.ProductSizeMiddleTables.Add(productSizeMiddleTable);
            _dbCotnext.SaveChanges();

            return RedirectToAction("Index", new { productId = productSizeMiddleTable.ProductId });
        }

        [HttpPost]
        public IActionResult Delete(int productId, int productSizeId)
        {
            var productSize = _dbCotnext
                .ProductSizeMiddleTables
                .SingleOrDefault(productSize => productSize.ProductId == productId && productSize.ProductSizeId == productSizeId);

            _dbCotnext.Remove(productSize);
            _dbCotnext.SaveChanges();

            return RedirectToAction("Index", new { productId = productSize.ProductId });
        }
    }
}
