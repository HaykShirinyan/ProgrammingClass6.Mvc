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
        private ApplicationDbContext _context;
        public ProductTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ProductType> productTypes = _context.ProductTypes.ToList();
         
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
                _context.ProductTypes.Add(productType);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit1(int id)
        {
            var productType = _context
            .ProductTypes.SingleOrDefault(pt => pt.Id == id);

            return View(productType);
        }

        [HttpPost]
        public IActionResult Edit(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _context.ProductTypes.Update(productType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

    }
}
