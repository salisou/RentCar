using RentCar.Application.Features.CQRS.Results.AboutResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAboutQueryResult>> Handler()
        {
            var banners = await _repository.GetAllAsync();
            var results = banners.Select(b => new GetAboutQueryResult
            {
                AboutId = b.BannerId,
                Title = b.Title,
                Description = b.Description,
                ImageUrl = b.VideoUrl // Assuming VideoUrl is used as ImageUrl for the result
            }).ToList();
            return results;
        }
    }
}
