using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUi.Controllers
{
    public class UiLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
