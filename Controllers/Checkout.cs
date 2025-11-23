using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EcomWebsite.Models;
using EcomWebsite.Data;

namespace EcomWebsite.Controllers
{
    [Route("Checkout")]
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;
        private readonly ApplicationDbContext _context;

        public CheckoutController(ILogger<CheckoutController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(UserCredentials credential)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            credential.Email = User.Identity.Name;
            _context.UserCredential.Add(credential);
            _context.SaveChanges();

            return RedirectToAction("CheckoutItem");
        }

        [HttpGet("CheckoutItem/{id?}")]
        public IActionResult CheckoutItem(int? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            if(id == null)
            {
                return View();
            }

            var email = User.Identity.Name;
            var userData = _context.UserCredential.SingleOrDefault(u => u.Email.ToLower() == email.ToLower());

            var product = _context.UserCart.SingleOrDefault(i => i.ProductId == id);
            
            if (userData == null)
            {
                _context.UserCart.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            _context.UserCart.Remove(product);
            _context.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}