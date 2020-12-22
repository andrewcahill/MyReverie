using Microsoft.AspNetCore.Mvc;

namespace Goals.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}