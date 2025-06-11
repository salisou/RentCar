using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.CarPricingDtos;

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

            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7265/api/CarPricings");

            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                var cars = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(json);

                return View(cars);
            }

            // In caso di errore API, ritorna una lista vuota per evitare NullReferenceException
            return View(new List<ResultCarPricingWithCarDto>());
        }
    }
}
