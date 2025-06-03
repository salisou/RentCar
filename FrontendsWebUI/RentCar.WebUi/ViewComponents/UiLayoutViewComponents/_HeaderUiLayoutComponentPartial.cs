using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUi.ViewComponents.UiLayoutViewComponents
{
    public class _HeaderUiLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // You can pass any model or data to the view if needed
            return View();
        }
    }
}
