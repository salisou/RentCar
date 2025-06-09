using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.ServiceDtos;

namespace RentCar.WebUi.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7265/api/Services");
            if (response.IsSuccessStatusCode)
            {
                var services = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<List<ResultServiceDto>>(services);
                return View(dto);
            }
            return View();
        }
    }
}
