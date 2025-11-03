using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
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
            var ViewModel= new ProductSizeViewModel
            {
                ProductSize = new ProductSize { ProductId = productId },
                Sizes = _dbContext.Sizes.ToList(),
                ProductSizes = _dbContext.ProductSizes
                .Include(ps => ps.Size)
                .Where(ps => ps.ProductId == productId)
                .ToList()
            };
            return View(ViewModel);
        }
        [HttpGet]
        public IActionResult Create(int productId)
        {
            var productSize = new ProductSize();

            productSize.ProductId = productId;
            var viewModel = new ProductSizeViewModel
            {
                ProductSize = productSize,
                Sizes = _dbContext.Sizes.ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(ProductSizeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ProductSizes.Add(viewModel.ProductSize);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", new { productId = viewModel.ProductSize.ProductId });
            }
            viewModel.Sizes = _dbContext.Sizes.ToList();
            return View(viewModel);
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
            return RedirectToAction("Index", new { productId });


        }
    }
}
