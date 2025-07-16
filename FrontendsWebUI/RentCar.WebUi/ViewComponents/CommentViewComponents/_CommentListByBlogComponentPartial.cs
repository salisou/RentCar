using Microsoft.AspNetCore.Mvc;
using RentCar.Dto.CommentDtos;

namespace RentCar.WebUi.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"https://localhost:7265/api/Comments?blogId={blogId}");

            if (response.IsSuccessStatusCode)
            {
                var comments = await response.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
                return View(comments);
            }

            return View(new List<ResultCommentDto>());
        }

    }
}
