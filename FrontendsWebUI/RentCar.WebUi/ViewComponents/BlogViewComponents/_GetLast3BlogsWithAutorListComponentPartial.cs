using Microsoft.AspNetCore.Mvc;
using RentCar.Dto.BlogDto;

namespace RentCar.WebUi.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogsWithAutorListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _GetLast3BlogsWithAutorListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7265/api/Blogs/GetLast3BlogsWithAuthors");
            if (response.IsSuccessStatusCode)
            {
                var blogs = await response.Content.ReadFromJsonAsync<List<ResultLast3BlogsWithAuthorsDto>>();
                return View(blogs);
            }
            return View();
        }
    }
}
