using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUi.ViewComponents.UiLayoutViewComponents
{
    public class _FooterUiLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
