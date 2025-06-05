using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.BannerDtos;

namespace RentCar.WebUi.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUiLayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCoverUiLayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7265/api/Banners");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var banners = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(banners);
            }
            return View();
        }
    }
}
