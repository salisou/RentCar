using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.FooterAddressDtos;

namespace RentCar.WebUi.ViewComponents.FooterAdressComponents
{
    public class _FooterAddressComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7265/api/FooterAddresses");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
