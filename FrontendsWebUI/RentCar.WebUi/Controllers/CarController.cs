using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.CarDtos;

namespace RentCar.WebUi.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "CARS ";
            ViewBag.v2 = "Our Premium Cars";
            // Fetching car data from the API
            var client = _httpClientFactory.CreateClient();
            // Ensure the API is running and accessible at the specified URL
            var result = await client.GetAsync("https://localhost:7265/api/Cars/with-brand");
            List<ResultCarWithBrandDto> cars = new();

            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                cars = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(json) ?? new List<ResultCarWithBrandDto>();
            }
            return View(cars);
        }
    }
}
