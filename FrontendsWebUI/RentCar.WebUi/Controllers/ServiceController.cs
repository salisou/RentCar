using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUi.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "SERVICES ";
            ViewBag.v2 = "Our Premium Service";
            return View();
        }
    }
}
