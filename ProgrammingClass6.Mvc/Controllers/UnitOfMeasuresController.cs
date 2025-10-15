using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasuresController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public UnitOfMeasuresController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var unitOfMeasures = _dbcontext
                .UnitOfMeasures
                .Include(uom => uom.UnitOfMeasureValu)
                .ToList();
            
            return View(unitOfMeasures);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.UnitOfMeasureValues = _dbcontext.UnitOfMeasureValues.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.UnitOfMeasures.Add(unitOfMeasure);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnitOfMeasureValues = _dbcontext.UnitOfMeasureValues.ToList();
            return View(unitOfMeasure);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var unitOfMeasure = _dbcontext.UnitOfMeasures.
                SingleOrDefault(uom => uom.Id == id);

            ViewBag.UnitOfMeasureValues = _dbcontext.UnitOfMeasureValues.ToList();
            return View(unitOfMeasure);
        }
        [HttpPost]
        public IActionResult Edit(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.UnitOfMeasures.Update(unitOfMeasure);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnitOfMeasureValues = _dbcontext.UnitOfMeasureValues.ToList();
            return View(unitOfMeasure);
        }
    }
}
