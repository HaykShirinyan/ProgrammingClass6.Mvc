using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasuresController(ApplicationDbContext dbContext) : Controller
    {
        private ApplicationDbContext _dbContext = dbContext;

        [HttpGet]
        public IActionResult Index()
        {
            List<UnitOfMeasure> unitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(unitOfMeasures);
        }

        [HttpGet]
        public IActionResult Create()
        {
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

            return View();
        }
        

        [HttpGet]
        public IActionResult Edit(int id)
        {
            UnitOfMeasure unitOfMeasure = _dbContext.UnitOfMeasures.SingleOrDefault(p => p.Id == id);

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

            return View();
        }
    }
}
