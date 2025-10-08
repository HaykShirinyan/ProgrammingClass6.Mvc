using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductTypeSizesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ProductTypeSizesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index(int producttypeId)
        {
            ViewBag.ProductTypeId = producttypeId;
            var productTypeSizes = dbContext
                .ProductTypeSizes
                .Include(pts => pts.Size)
                .Where(pts => pts.ProductTypeId == producttypeId)
                .ToList();
            return View(productTypeSizes);
        }
        [HttpGet]
        public IActionResult Create(int producttypeId)
        {
            ViewBag.ProductTypeId = producttypeId;
            ViewBag.Sizes = dbContext.Sizes.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductTypeSize productTypeSize)
        {

                dbContext.ProductTypeSizes.Add(productTypeSize);
                dbContext.SaveChanges();

                return RedirectToAction("Index", new { producttypeId = productTypeSize.ProductTypeId });

        }

        [HttpPost]

        public IActionResult Delete(int producttypeId, int sizeId)
        {
            var productTypeSize = dbContext.ProductTypeSizes
                .SingleOrDefault(pts => pts.ProductTypeId == producttypeId && pts.SizeId == sizeId);

            if (productTypeSize != null)
                {
                dbContext.ProductTypeSizes.Remove(productTypeSize);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index", new { producttypeId =productTypeSize?.ProductTypeId });

        }

    }
}
