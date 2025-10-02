using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public ProductTypesController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productTypes = _dbcontext
                .ProductTypes
                .Include(pt => pt.Manufacture)
                .ToList();

            return View(productTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Manufactures = new SelectList(_dbcontext.Manufactures, "Id", "Name");
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

            ViewBag.Manufactures = new SelectList(_dbcontext.Manufactures, "Id", "Name");
            return View(productType);
        }
               
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productType = _dbcontext.ProductTypes
                .SingleOrDefault(pt => pt.Id == id);

            if (productType == null)
                return NotFound();

            ViewBag.Manufactures = new SelectList(_dbcontext.Manufactures, "Id", "Name", productType.ManufactureId);

            return View(productType);
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.ProductTypes.Update(productType);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Manufactures = new SelectList(_dbcontext.Manufactures, "Id", "Name", productType.ManufactureId);

            return View(productType);
        }
    }
}
