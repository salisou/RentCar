using RentCar.Application.Features.CQRS.Queries.BannerQueries;
using RentCar.Application.Features.CQRS.Results.AboutResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handler(GetBannerByIdQuery getBannerByIdQuery)
        {
            var banner = await _repository.GetByIdAsync(getBannerByIdQuery.Id);
            if (banner == null)
            {
                return null!; // or throw an exception, depending on your error handling strategy
            }
            return new GetAboutByIdQueryResult
            {
                AboutId = banner.BannerId,
                Title = banner.Title,
                Description = banner.Description,
                ImageUrl = banner.VideoUrl // Assuming VideoUrl is used as ImageUrl for the result
            };
        }
    }
}
