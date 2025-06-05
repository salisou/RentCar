using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.ContactDtos;
using System.Text;

namespace RentCar.WebUi.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
            //var client = _httpClientFactory.CreateClient();
            //var result = await client.GetAsync("https://localhost:7265/api/Contacts");
            //List<ContactDto> contacts = new();
            //if (result.IsSuccessStatusCode)
            //{
            //    var json = await result.Content.ReadAsStringAsync();
            //    contacts = JsonConvert.DeserializeObject<List<ContactDto>>(json) ?? new();
            //}
            //return View(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent strContent = new(jsonData, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://localhost:7265/api/Contacts", strContent);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
