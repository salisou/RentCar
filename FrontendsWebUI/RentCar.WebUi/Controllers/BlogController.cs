using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.BlogDto;
using RentCar.WebUi.Models;

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

        //public async Task<IActionResult> BlogDetail(int id)
        //{
        //    if (id <= 0)
        //    {
        //        // Log dell'errore per debug
        //        Console.WriteLine("Errore: ID del blog non valido.");
        //        var errorModel = new ErrorViewModel
        //        {
        //            RequestId = "Invalid Blog ID",
        //            ShowRequestId = false
        //        };
        //        return View("Error", errorModel); // Passa il modello alla vista
        //    }

        //    ViewBag.v1 = "Blog Single";
        //    ViewBag.v2 = "Read our blog";
        //    ViewBag.blogid = id;

        //    return View();
        //}

        public IActionResult BlogDetail(int id)
        {
            if (id <= 0)
            {
                return View("Error", new ErrorViewModel { RequestId = "Invalid Blog ID" });
            }

            ViewBag.blogid = id;
            ViewBag.v1 = "Blog Single";
            ViewBag.v2 = "Read our blog";

            return View();
        }

    }
}
