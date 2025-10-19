using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using ProgrammingClass6.Mvc.ViewModels;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductColorsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(int productId)
        {
            var productColors = _dbContext
                .ProductColors
                .Include(pc => pc.Color)
                .Where(pc => pc.ProductId == productId)
                .ToList();

            ViewBag.ProductId = productId;
            return View(productColors);
        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            var viewModel = new ProductColorViewModel
            {
                ProductColor = new ProductColor
                {
                    ProductId = productId
                },
                Colors = _dbContext.Colors.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(ProductColorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new ProductColor
                {
                    ProductId = viewModel.ProductColor.ProductId,
                    ColorId = viewModel.ProductColor.ColorId
                };

                _dbContext.ProductColors.Add(entity);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", new { productId = entity.ProductId });
            }

            // refill dropdown if validation fails
            viewModel.Colors = _dbContext.Colors.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(int productId, int colorId)
        {
            var productColor = _dbContext.ProductColors
                .SingleOrDefault(pc => pc.ProductId == productId && pc.ColorId == colorId);

            if (productColor != null)
            {
                _dbContext.ProductColors.Remove(productColor);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Index", new { productId });
        }
    }
}
