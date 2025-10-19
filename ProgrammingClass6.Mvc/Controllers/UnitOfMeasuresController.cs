using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using ProgrammingClass6.Mvc.ViewModels;



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
            var viewModel = new UnitOfMeasureViewModel();
            {
                viewModel.UnitOfMeasureValues = _dbcontext.UnitOfMeasureValues.ToList();
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create (UnitOfMeasureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.UnitOfMeasures.Add(viewModel.UnitOfMeasure);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            viewModel.UnitOfMeasureValues = _dbcontext.UnitOfMeasureValues.ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var unitOfMeasure = _dbcontext.UnitOfMeasures.
                SingleOrDefault(uom => uom.Id == id);

            var viewModel = new UnitOfMeasureViewModel
            {
                UnitOfMeasure = unitOfMeasure,
                UnitOfMeasureValues = _dbcontext.UnitOfMeasureValues.ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit (UnitOfMeasureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.UnitOfMeasures.Update(viewModel.UnitOfMeasure);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            viewModel.UnitOfMeasureValues = _dbcontext.UnitOfMeasureValues.ToList();
            return View(viewModel);
        }
    }
}
