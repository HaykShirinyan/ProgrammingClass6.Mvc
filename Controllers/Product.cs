using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EcomWebsite.Data;
using EcomWebsite.Models;

namespace EcomWebsite.Controllers;

[Route("Product")]
public class Product : Controller
{
    private readonly ILogger<Product> _logger;
    private readonly ApplicationDbContext _context;

    public Product(ILogger<Product> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [Route("{id:int}")]
    public IActionResult Index(int id)
    {
        if (!User.Identity.IsAuthenticated)
        {
            return Redirect("/Identity/Account/Login");
        }

        var product = _context.Product.SingleOrDefault(p => p.Id == id);
        
        return View(product);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
