using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductSizesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductSizesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index(int productId)
        {
            ViewBag.ProductId = productId;
            var productSizes = _dbContext
                .ProductSizes
                .Include(ps => ps.Size)
                .Where(ps => ps.ProductId == productId)
                .ToList();
            return View(productSizes);
        }
        [HttpGet]
        public IActionResult Create(int productId)
        {
            var productSize = new ProductSize();

            productSize.ProductId = productId;
            ViewBag.Sizes = _dbContext.Sizes.ToList();

            return View(productSize);
        }
        [HttpPost]
        public IActionResult Create(ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ProductSizes.Add(productSize);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", new { productId = productSize.ProductId });
            }
            ViewBag.Sizes = _dbContext.Sizes.ToList();
            return View(productSize);
        }
        [HttpPost]
        public IActionResult Delete(int productId, int SizeId) 
            {
            var productSize = _dbContext
                .ProductSizes
                .SingleOrDefault(ps => ps.ProductId == productId && ps.SizeId == SizeId);
            if (productSize != null)
            {
                _dbContext.ProductSizes.Remove(productSize);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index", new { productId = productId });


        }
    }
}
