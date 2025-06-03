using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUi.ViewComponents.UiLayoutViewComponents
{
    public class _MainCoverUiLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
