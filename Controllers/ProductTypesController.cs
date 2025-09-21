using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using System.Collections.Generic;
using ProductType = ProgrammingClass6.Mvc.Models.ProductType;
namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _dbcontext;
        public ProductTypesController(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductType> productTypes = _dbcontext.ProductTypes.ToList();
         
            return View(productTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductType productType)
        { 
        if (ModelState.IsValid)
            {
                _dbcontext.ProductTypes.Add(productType);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit1(int id)
        {
            var productType = _dbcontext
            .ProductTypes.SingleOrDefault(pt => pt.Id == id);

            return View(productType);
        }

        [HttpPost]
        public IActionResult Edit(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.ProductTypes.Update(productType);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

    }
}
