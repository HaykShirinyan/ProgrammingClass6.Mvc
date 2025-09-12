using Microsoft.AspNetCore.Http;
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

        // GET: UnitOfMeasuresController
        public ActionResult Index()
        {
            List<UnitOfMeasure> unitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(unitOfMeasures);
        }

        // GET: UnitOfMeasuresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnitOfMeasuresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnitOfMeasuresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnitOfMeasuresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnitOfMeasuresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnitOfMeasuresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnitOfMeasuresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
