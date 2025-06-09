using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUi.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
