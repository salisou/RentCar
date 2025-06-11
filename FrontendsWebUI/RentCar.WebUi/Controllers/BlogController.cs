using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.BlogDto;

namespace RentCar.WebUi.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Blog List";

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7265/api/Blogs/GetAllBlogsWithAuthors");

            if (response.IsSuccessStatusCode)
            {
                var blogs = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultAllBlogWithAuthorDto>>(blogs);
                return View(value);
            }

            return View(new List<ResultAllBlogWithAuthorDto>());
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            return View();
        }
    }
}
