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
        public IActionResult Create(ProductType producttype)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ProductTypes.Add(producttype);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var producttype = _dbContext
                .ProductTypes
                .SingleOrDefault(p => p.Id == Id);

            return View(producttype);
        }
    }
}
