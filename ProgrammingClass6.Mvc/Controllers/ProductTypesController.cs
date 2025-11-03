using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using ProgrammingClass6.Mvc.ViewModels;
using System.Security.Claims;

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
                ProductTypeCart =  new ProductTypeCart
                {
                    Name = productType.Name,
                    Brand = productType.Brand,
                    Type = productType.Type,
                    Price = productType.Price
                }

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
                    Name = viewModel.ProductTypeCart.Name,
                    Brand = viewModel.ProductTypeCart.Brand,
                    Type = viewModel.ProductTypeCart.Type,
                    Price = viewModel.ProductTypeCart.Price,
                    TotalPrice = viewModel.ProductTypeCart.Price
                };

                _dbcontext.ProductTypeCarts.Add(productTypeCart);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index", "ProductTypeCarts");
            }
            viewModel.ProductTypeCart = _dbcontext.ProductTypeCarts
                .Include(pt => pt.Id)
                .SingleOrDefault(pt => pt.Id == viewModel.ProductTypeCart.Id);

            return View(viewModel);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var productType = _dbcontext.ProductTypes
                .SingleOrDefault(pt => pt.Id == id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        [HttpGet]
        public IActionResult Cart()
        {
            var cartItems = _dbcontext.ProductTypeCarts.ToList();
            return View(cartItems);
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var productType = _dbcontext.ProductTypeCarts.SingleOrDefault(pt => pt.Id == id);
            if (productType != null)
            {
                _dbcontext.ProductTypeCarts.Remove(productType);
                _dbcontext.SaveChanges();
            }
            return RedirectToAction("Cart");
        }

        public IActionResult AnotherAction()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }


    }

} 