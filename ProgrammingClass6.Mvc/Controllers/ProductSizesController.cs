using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using Microsoft.EntityFrameworkCore;

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

            var productSize = _dbContext
                .ProductSizes
                .Include(productSize => productSize.Size)
                .Where(productSize => productSize.ProductId == productId)
                .ToList();

            return View(productSize);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var productSize = new ProductSize();

            productSize.ProductId = productId;

            ViewBag.Size = _dbContext.Sizes.ToList();

            return View(productSize);
        }

        [HttpPost]
        public IActionResult Create(ProductSize productSize)
        {
            _dbContext.ProductSizes.Add(productSize);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = productSize.ProductId });
        }

        [HttpPost]
        public IActionResult Delete(int productId, int sizeId)
        {
            var productSize = _dbContext
                .ProductSizes
                .SingleOrDefault(ps => ps.ProductId == productId && ps.SizeId == sizeId);

            if (productSize != null)
            {
                _dbContext.ProductSizes.Remove(productSize);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", new { productId = productId });
        }


    }


}

