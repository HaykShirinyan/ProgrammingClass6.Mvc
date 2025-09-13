using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
namespace ProgrammingClass6.Mvc.Controllers
{
    public class UnitOfMeasureController : Controller
    {
        private ApplicationDbContext _context;
        public UnitOfMeasureController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Models.UnitOfMeasure> unitOfMeasures = _context.UnitOfMeasures.ToList();

            return View(unitOfMeasures);
        }
    }
}
