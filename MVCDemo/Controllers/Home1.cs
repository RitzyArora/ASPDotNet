using Microsoft.AspNetCore.Mvc;

namespace MVCDemo.Controllers
{
    public class Home1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
