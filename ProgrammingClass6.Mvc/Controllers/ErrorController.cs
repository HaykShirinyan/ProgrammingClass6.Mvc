// Controllers/ErrorController.cs
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ProgrammingClass6.Mvc.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound");
            }

            return View("Error");
        }
    }
}
