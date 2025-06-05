using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.ServiceDtos;

namespace RentCar.WebUi.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7265/api/Services");
            List<ResultServiceDto> services = new();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                services = JsonConvert.DeserializeObject<List<ResultServiceDto>>(json) ?? new List<ResultServiceDto>();
            }

            return View(services);
        }
    }
}
