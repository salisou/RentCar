using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUi.ViewComponents.DefaultViewComponents
{
    public class _DefaultStaticsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
