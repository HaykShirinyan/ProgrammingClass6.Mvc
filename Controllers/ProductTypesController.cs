using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductTypesController(ApplicationDbContext dbcontext) : Controller
    {
        private readonly ApplicationDbContext _dbcontext = dbcontext;

        [HttpGet]
        public IActionResult Index()
        {
            var productTypes = _dbcontext
                .ProductTypes
                .Include(ProductType => ProductType.Manufacture)
                .ToList();

            return View(productTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductType productTypes)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.ProductTypes.Add(productTypes);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productType = _dbcontext
                .ProductTypes
                .SingleOrDefault(pt => pt.Id == id);

            return View(productType);
        }

        [HttpPost]
        public IActionResult Edit(ProductType productTypes)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.ProductTypes.Update(productTypes);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productTypes);
        }
    }
}