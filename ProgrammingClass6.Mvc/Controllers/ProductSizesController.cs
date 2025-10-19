using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Data.Migrations;
using ProgrammingClass6.Mvc.Models;
using ProgrammingClass6.Mvc.ViewModels;

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
            List<ProductSize> productSizes = _dbContext
                .ProductSizes
                .Include(productSize => productSize.Size)
                .Where(productSize => productSize.ProductId == productId)
                .ToList();

            return View(productSizes);
        }

        public IActionResult Create(int productId)
        {
            var productSize = new ProductSize();

            productSize.ProductId = productId;

            var viewModel = new ProductSizesViewModels
            {
                ProductSize = productSize,
                ProductSizes = _dbContext.ProductSizes.ToList()
            };
            
            return View(viewModel);            
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
                .SingleOrDefault(productSize => productSize.ProductId == productId && productSize.SizeId == sizeId);

            _dbContext.Remove(productSize);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = productSize.ProductId });
        }
    }
}
