using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasuresController(ApplicationDbContext dbContext) : Controller
    {
        private ApplicationDbContext _dbContext = dbContext;

        public IActionResult Index()
        {
            List<UnitOfMeasure> products = _dbContext.UnitOfMeasures.ToList();

            return View(products);
        }
    }
}
