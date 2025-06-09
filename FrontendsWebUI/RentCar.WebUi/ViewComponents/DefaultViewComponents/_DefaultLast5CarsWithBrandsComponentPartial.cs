

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.CarDtos;

namespace RentCar.WebUi.ViewComponents.DefaultViewComponents
{
    public class _DefaultLast5CarsWithBrandsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7265/api/Cars/GetLast5CarsWithBrands");
            if (response.IsSuccessStatusCode)
            {
                var cars = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<List<ResultLastCarsWithBrandsDto>>(cars);
                return View(dto);
            }
            return View();
        }
    }
}
