using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.AuthorDtos;

namespace RentCar.WebUi.ViewComponents.BlogViewComponents
{
    public class _BlogDeailsAuthorComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDeailsAuthorComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.Id = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7265/api/Blogs/GetBlogByAuthorId?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<ResultGetAuthorByBlogAuthorIdDto>>(content);
                if (responseData == null || !responseData.Any())
                {
                    // Log the error or handle the case where no data is returned
                    Console.WriteLine($"No authors found for blog ID {id}");
                    return View(null); // Return an empty view or a default view
                }
                return View(responseData);
            }
            else
            {
                // Handle error or return a default view
                return View(null);
            }
        }
    }
}
