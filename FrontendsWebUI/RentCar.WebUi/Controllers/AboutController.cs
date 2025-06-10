using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUi.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "About ";
            ViewBag.v2 = "Our Company";
            return View();
        }
    }
}
