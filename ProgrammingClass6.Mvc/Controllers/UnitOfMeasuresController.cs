using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasuresController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public UnitOfMeasuresController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            var unitOfMeasures = _dbcontext.UnitOfMeasures.ToList();

            return View(unitOfMeasures);
        }
    }
}
