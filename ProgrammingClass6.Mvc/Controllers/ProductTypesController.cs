using Microsoft.AspNetCore.Mvc;
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
            List<ProductType> productTypes = _dbcontext.ProductTypes.ToList();

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
                _dbcontext.ProductTypes.Add(productType);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productType);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productType = _dbcontext.ProductTypes.
                SingleOrDefault(pt => pt.Id == id);
            if (productType == null)
            {
                return NotFound();
            }
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
