using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasuresController : Controller
    {
        private ApplicationDbContext _dbContext;
        public UnitOfMeasuresController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Models.UnitOfMeasure> unitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(unitOfMeasures);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UnitOfMeasure unitofmeasures)
        {
            if (ModelState.IsValid)
            {
                _dbContext.UnitOfMeasures.Add(unitofmeasures);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var unitofmeasure = _dbContext
                .UnitOfMeasures
                .SingleOrDefault(p => p.Id == Id);

            return View(unitofmeasure);
        }
    }
}
