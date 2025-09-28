using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasureController : Controller
    {
        private ApplicationDbContext _dbContext;

        public UnitOfMeasureController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<UnitOfMeasure> unitOfMeasures = _dbContext
                .UnitOfMeasures
                .Include(UnitOfMeasure => UnitOfMeasure.Manufacture)
                .ToList();

            return View(unitOfMeasures);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Manufactures = _dbContext.Manufactures.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _dbContext.UnitOfMeasures.Add(unitOfMeasure);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Manufactures = _dbContext.Manufactures.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var unitOfMeasure = _dbContext
                .UnitOfMeasures
                .SingleOrDefault(pt => pt.Id == id);
            ViewBag.Manufactures = _dbContext.Manufactures.ToList();

            return View(unitOfMeasure);
        }
        [HttpPost]
        public IActionResult Edit(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _dbContext.UnitOfMeasures.Update(unitOfMeasure);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Manufactures = _dbContext.Manufactures.ToList();
            return View(unitOfMeasure);
        }
    }
}
