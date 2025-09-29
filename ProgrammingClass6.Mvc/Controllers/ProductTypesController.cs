using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductTypesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductType> productTypes = _dbContext.ProductTypes.ToList();

            return View(productTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ProductTypes.Add(productType);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productType = _dbContext.ProductTypes.SingleOrDefault(p => p.Id == id);

            return View(productType);
        }

        [HttpPost]
        public IActionResult Edit(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ProductTypes.Update(productType);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
