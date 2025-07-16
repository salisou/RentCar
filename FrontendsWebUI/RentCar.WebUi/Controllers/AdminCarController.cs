using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUi.Controllers
{
    public class AdminCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminNavBarPartial()
        {
            return PartialView();
        }
    }
}
