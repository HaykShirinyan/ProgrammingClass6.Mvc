using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasureController : Controller
    {
        private ApplicationDbContext _dbcontext;

        public UnitOfMeasureController(ApplicationDbContext context)
        {
            _dbcontext = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<UnitOfMeasure> unitOfMeasures = _dbcontext.UnitOfMeasures.ToList();

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
                _dbcontext.UnitOfMeasures.Add(unitOfMeasure);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var unitOfMeasure = _dbcontext
                .UnitOfMeasures
                .SingleOrDefault(pt => pt.Id == id);

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
            return View(unitOfMeasure);
        }
    }
}
