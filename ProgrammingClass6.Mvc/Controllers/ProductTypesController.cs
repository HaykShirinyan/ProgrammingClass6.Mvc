using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductTypesController(ApplicationDbContext dbContext) : Controller
    {
        private ApplicationDbContext _dbContext = dbContext;

        public IActionResult Index()
        {
            List<ProductType> products = _dbContext.ProductTypes.ToList();

            return View(products);
        }
    }
}
