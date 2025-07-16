using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Dto.BlogDto;

namespace RentCar.WebUi.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.Id = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7265/api/Blogs/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var blogDetails = JsonConvert.DeserializeObject<ResultGetBlogByIdDto>(content);
                if (blogDetails == null)
                {
                    // Log dell'errore per debug  
                    Console.WriteLine($"Errore: Il blog con ID {id} non è stato trovato.");
                    return View("Error"); // Vista di errore in caso di fallimento  
                }
                return View(blogDetails); // Restituisce i dettagli del blog se la richiesta ha successo
            }
            else
            {
                // Gestione dell'errore se la richiesta non ha successo  
                Console.WriteLine($"Errore: Impossibile recuperare il blog con ID {id}. Stato della risposta: {responseMessage.StatusCode}");
                return View("Error"); // Vista di errore in caso di fallimento
            }
        }
    }
}
