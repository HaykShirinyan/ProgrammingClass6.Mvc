using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Data.Migrations;
using ProgrammingClass6.Mvc.Models;
using UnitOfMeasure = ProgrammingClass6.Mvc.Models.UnitOfMeasure;
namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasureController : Controller
    {
        private ApplicationDbContext _context;
        private readonly object _dbContext;

        public UnitOfMeasureController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Models.UnitOfMeasure> unitOfMeasures = _context.UnitOfMeasures.ToList();

            return View(unitOfMeasures);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creat(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _context.UnitOfMeasures.Add(unitOfMeasure);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var unitOfMeasure = _context
                .UnitOfMeasures.SingleOrDefault(pt => pt.Id == id);

            return View(unitOfMeasure);
        }
        [HttpPost]
        public IActionResult Edit(UnitOfMeasure unitOfMeasure)
        {
            if (ModelState.IsValid)
            {
                _context.UnitOfMeasures.Update(unitOfMeasure);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unitOfMeasure);
        }
    }
}
