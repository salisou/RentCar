using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.CategoryDtos;

namespace RentCar.WebUi.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCategoryComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7265/api/Categories");
            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categories);
                return View(responseData);
            }
            return View(new List<ResultCategoryDto>());
        }
    }
}
