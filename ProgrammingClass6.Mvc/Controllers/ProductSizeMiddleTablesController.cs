using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using ProgrammingClass6.Mvc.ViewModels;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductSizeMiddleTablesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductSizeMiddleTablesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            var productSizes = _dbContext
                .ProductSizeMiddleTables
                .Include(ps => ps.ProductSize)
                .Where(ps => ps.ProductId == productId)
                .ToList();

            return View(productSizes);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var viewModel = new ProductSizeMiddleTableViewModel
            {
                ProductSizeMiddleTable = new ProductSizeMiddleTable
                {
                    ProductId = productId
                },
                ProductSizes = _dbContext.ProductSizes.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductSizeMiddleTableViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var middle = new ProductSizeMiddleTable
                {
                    ProductId = viewModel.ProductSizeMiddleTable.ProductId,
                    ProductSizeId = viewModel.ProductSizeMiddleTable.ProductSizeId
                };

                _dbContext.ProductSizeMiddleTables.Add(middle);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", new { productId = middle.ProductId });
            }

            viewModel.ProductSizes = _dbContext.ProductSizes.ToList();
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Delete(int productId, int productSizeId)
        {
            var productSize = _dbContext.ProductSizeMiddleTables
                .SingleOrDefault(ps => ps.ProductId == productId && ps.ProductSizeId == productSizeId);

            if (productSize != null)
            {
                _dbContext.ProductSizeMiddleTables.Remove(productSize);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", new { productId });
        }
    }
}
