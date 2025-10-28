using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using ProgrammingClass6.Mvc.ViewModels;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public ProductTypesController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductType> productTypes = _dbcontext
                .ProductTypes
                .Include(pt => pt.Manufacturer)
                .ToList();

            return View(productTypes);

        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ProductTypeViewModel();
            {
                viewModel.Manufacturers = _dbcontext.Manufacturers.ToList();
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(ProductTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.ProductTypes.Add(viewModel.ProductType);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            viewModel.Manufacturers = _dbcontext.Manufacturers.ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var productType = _dbcontext.ProductTypes.
                SingleOrDefault(pt => pt.Id == id);

            var viewModel = new ProductTypeViewModel
            {
                ProductType = productType,
                Manufacturers = _dbcontext.Manufacturers.ToList()
            };


            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ProductTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.ProductTypes.Update(viewModel.ProductType);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.Manufacturers = _dbcontext.Manufacturers.ToList();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult AddToBag(int id)
        {
            var productType = _dbcontext.ProductTypes
                .Include(pt => pt.Manufacturer)
                .SingleOrDefault(pt => pt.Id == id);

            if (productType == null)
            {
                return NotFound();
            }

            var viewModel = new ProductTypeItemViewModel
            {
                ProductType = productType
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddToBag(ProductTypeItemViewModel viewModel)
        {
         
            if (ModelState.IsValid)
            {
                var productTypeCart = new ProductTypeCart
                {
                    Name = viewModel.ProductType.Name,
                    Brand = viewModel.ProductType.Brand,
                    Type = viewModel.ProductType.Type,
                    Price = viewModel.ProductType.Price,
                    TotalPrice = viewModel.ProductType.Price
                };

                _dbcontext.ProductTypeCarts.Add(productTypeCart);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index", "ProductTypeCarts");
            }
            viewModel.ProductType = _dbcontext.ProductTypes
                .Include(pt => pt.Manufacturer)
                .SingleOrDefault(pt => pt.Id == viewModel.ProductType.Id);

            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var productType = _dbcontext.ProductTypes
                .SingleOrDefault(pt => pt.Id == id);
            if (productType != null)
            {
                _dbcontext.ProductTypes.Remove(productType);
                _dbcontext.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }

} 