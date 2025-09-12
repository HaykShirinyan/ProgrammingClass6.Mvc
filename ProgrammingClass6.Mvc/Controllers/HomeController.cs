using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult About() => View();
    public IActionResult Menu() => View();
}
