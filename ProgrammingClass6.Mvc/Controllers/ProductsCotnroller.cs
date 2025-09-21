using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

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

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Product product)
		{
			_dbContext.Products.Add(product);
			_dbContext.SaveChanges();

			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var product = _dbContext
				.Products
				.FirstOrDefault(p=> p.Id == id);

			return View(product);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Product product)
		{
			_dbContext.Products.Update(product);
			_dbContext.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
