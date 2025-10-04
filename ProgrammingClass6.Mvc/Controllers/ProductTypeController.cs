using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            List<ProductType> productTypes = _dbContext.ProductTypes.Include(p => p.UnitOfMeasure).ToList();

            return View(productTypes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();
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

            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(producttype);
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

            ViewBag.UnitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(productType);
        }
    }
}
