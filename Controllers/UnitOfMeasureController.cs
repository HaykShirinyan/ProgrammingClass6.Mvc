using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasureController : Controller
    
    {
        private ApplicationDbContext _DbContext;
        public UnitOfMeasureController(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var unitOfMeasures = _DbContext
                .UnitOfMeasures
                .Include(UnitOfMeasure => UnitOfMeasure.Manufacture)
                .ToList();

            return View(unitOfMeasures);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Manufactures = _DbContext.Manufactures.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _DbContext.UnitOfMeasures.Add(unitOfMeasure);
                _DbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Manufactures = _DbContext.Manufactures.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var unitOfMeasure = _DbContext
                .UnitOfMeasures
                .SingleOrDefault(pt => pt.Id == id);
            ViewBag.Manufactures = _DbContext.Manufactures.ToList();

            return View(unitOfMeasure);
        }
        [HttpPost]
        public IActionResult Edit(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _DbContext.UnitOfMeasures.Update(unitOfMeasure);
                _DbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Manufactures = _DbContext.Manufactures.ToList();
            return View(unitOfMeasure);
        }
    }
}