using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using System.Security.Cryptography.X509Certificates;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductTypesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<ProductType> productTypes = _dbContext.ProductTypes.ToList();

            return View(productTypes);
        }

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
            var productType = _dbContext
                .ProductTypes
                .SingleOrDefault(dbProductTypeRow => dbProductTypeRow.Id == id);
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
            return View(productType);
        }
    }
}
