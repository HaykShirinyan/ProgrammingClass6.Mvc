﻿using Microsoft.AspNetCore.Mvc;
using ProgrammingClass6.Mvc.Data;
using ProgrammingClass6.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _dbContext.Products.Include(product => product.ProductType).ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ProductTypes = _dbContext.ProductTypes.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ProductTypes = _dbContext.ProductTypes.ToList();

            return View();

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            ViewBag.ProductTypes = _dbContext.ProductTypes.ToList();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");

            }

            ViewBag.ProductTypes = _dbContext.ProductTypes.ToList();

            return View();
        }
    }
}
