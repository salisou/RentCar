using Microsoft.AspNetCore.Mvc;

namespace RentCar.WebUi.ViewComponents.UiLayoutViewComponents
{
    public class _ScriptUiLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
