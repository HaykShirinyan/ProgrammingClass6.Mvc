using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using System.Collections.Generic;
using ProgrammingClass6.Mvc.Migrations;
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
        public IActionResult Creat(ProductType productType)
        { 
        if (ModelState.IsValid)
            {
                _context.ProductTypes.Add(productType);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();

            [HttpGet]
            Public IActionResult Edit(int id)
            {
                var productType = _context
                    .ProductTypes.SingleOrDefault(pt => pt.Id == id);
                return View(productType);
            }

            [HttpPost]
            Public IActionResult Edit(ProductType productType)
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
}
