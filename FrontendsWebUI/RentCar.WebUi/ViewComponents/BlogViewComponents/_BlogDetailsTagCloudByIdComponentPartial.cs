using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.TagCloudDtos;

namespace RentCar.WebUi.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsTagCloudByIdComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsTagCloudByIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.Id = id;
            var client = _httpClientFactory.CreateClient();
            var response = client.GetAsync($"https://localhost:7265/api/TagCloud/GetTagCloudByBlogId/{id}");

            if (response.Result.IsSuccessStatusCode)
            {
                var jsonData = await response.Result.Content.ReadAsStringAsync();
                var tagCloud = JsonConvert.DeserializeObject<List<ResultGetByBlogTagCloudDto>>(jsonData);
                return View(tagCloud);
            }

            return View();
        }
    }
}
