using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductTypesControllers : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductTypesControllers(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: ProductTypesControllers
        public ActionResult Index()
        {
            List<ProductType> productTypes = _dbContext.ProductTypes.ToList();

            return View(productTypes);
        }

        // GET: ProductTypesControllers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductTypesControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductTypesControllers/Create
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

        // GET: ProductTypesControllers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductTypesControllers/Edit/5
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

        // GET: ProductTypesControllers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductTypesControllers/Delete/5
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
