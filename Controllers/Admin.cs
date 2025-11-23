using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcomWebsite.Models;
using EcomWebsite.Data;

namespace EcomWebsite.Controllers;

public class Admin : Controller
{
    private readonly ILogger<Admin> _logger;
    private readonly ApplicationDbContext _context;

    public Admin(ILogger<Admin> logger, ApplicationDbContext context)
    {

        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {   
        if (User.Identity.Name != "AdminUser@Ecom.com")
        {
            return NotFound();
        }
        var products = _context.Product.ToList();
        return View(products);
    }

    [HttpGet]
    public IActionResult Create()
    {
        if (User.Identity.Name != "AdminUser@Ecom.com")
        {
            return Redirect("/Account/AccessDenied");
        }

        return View();
    }

    [HttpPost]
    public IActionResult Create(Products product, IFormFile ImageFile)
    {
        if (ImageFile != null && ImageFile.Length > 0)
        {
        
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            var filePath = Path.Combine(uploads, ImageFile.FileName);


            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                ImageFile.CopyTo(stream); 
            }

        
            product.Image = "/uploads/" + ImageFile.FileName;
        }
        
        _context.Product.Add(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
        
    }

    [HttpGet("Admin/Delete/{id}")]
    public IActionResult Delete(int id)
    {
        var dataItem = _context.Product.SingleOrDefault(p => p.Id == id);
        if(dataItem != null)
        {
            _context.Product.Remove(dataItem);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var product = _context.Product.SingleOrDefault(p => p.Id == id);
        if(product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Products product)
    {
        _context.Product.Update(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Users()
    {
        var userData = _context.Users.ToList();
        return View(userData);
    }

    public IActionResult UserDelete(string user)
    {
        var userData = _context.Users.SingleOrDefault(u => u.UserName == user);
        var userCartData = _context.UserCart.Where(c => c.User == user);

        if(userCartData.Any())
        {
            _context.UserCart.RemoveRange(userCartData);
            _context.SaveChanges();
        }

        if(userData != null)
        {
            _context.Users.Remove(userData);
            _context.SaveChanges();
        }

        return RedirectToAction("Users");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}