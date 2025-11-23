using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EcomWebsite.Models;
using EcomWebsite.Data;

namespace EcomWebsite.Controllers;

[Route("Cart")]
public class Cart : Controller
{
    private readonly ILogger<Cart> _logger;
    private readonly ApplicationDbContext _context;

    public Cart(ILogger<Cart> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        if ((!User.Identity.IsAuthenticated) || (User.Identity.Name == "AdminUser@Ecom.com"))
        {
            return Redirect("/Identity/Account/Login");
        }

        string userName = User.Identity.Name;
        
        var userItemCart = _context.UserCart.Where(c => c.User == userName).ToList();
        ViewBag.CartItems = userItemCart;

        var productIds = userItemCart.Select(c => c.ProductId).ToList();
        
        var productData = _context.Product.Where(p => productIds.Contains(p.Id)).ToList();
        
        return View(productData);
    }

    [HttpGet("Add/{id}")]
    public IActionResult Add(int id)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return Redirect("/Identity/Account/Login");
        }

        var userCart = new CartItems
        {
            ProductId = id,
            User = User.Identity.Name
        };
        
        _context.UserCart.Add(userCart);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return Redirect("/Identity/Account/Login");
        }

        var userCart = _context.UserCart.SingleOrDefault(c => c.Id == id);
        
        if(userCart != null)
        {
            _context.UserCart.Remove(userCart);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }


    [Route("Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}