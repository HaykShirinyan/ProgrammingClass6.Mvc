using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EcomWebsite.Models;
using EcomWebsite.Data;
using Microsoft.AspNetCore.Authorization;

namespace EcomWebsite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var products = _context.Product.ToList();
        if(User.Identity.IsAuthenticated)
        {
            if (User.Identity.Name == "AdminUser@Ecom.com")
            {
                return Redirect("/Admin");
            } 
        }
        
        return View(products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}