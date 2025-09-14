using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;

namespace ProgrammingClass6.Mvc.Controllers
{
	public class ProductsController : Controller
	{
		private ApplicationDbContext _dbContext;
		public ProductsController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index()
		{
			var products = _dbContext.Products.ToList();
			return View(products);
		}
	}
}