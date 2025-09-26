using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasuresController : Controller
    {
        private ApplicationDbContext _dbContext;
        public UnitOfMeasuresController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Models.UnitOfMeasure> unitOfMeasures = _dbContext.UnitOfMeasures.ToList();

            return View(unitOfMeasures);
         
        }
    }
}
