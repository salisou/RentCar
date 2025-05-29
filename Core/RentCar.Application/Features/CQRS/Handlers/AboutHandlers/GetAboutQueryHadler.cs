using RentCar.Application.Features.CQRS.Results.AboutResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHadler
    {
        private readonly IRepository<About> _repository;
        public GetAboutQueryHadler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAboutQueryResult>> Handle()
        {
            List<About> abouts = await _repository.GetAllAsync();
            return abouts.Select(a => new GetAboutQueryResult
            {
                AboutId = a.AboutId,
                Title = a.Title ?? string.Empty,
                Description = a.Description ?? string.Empty,
                ImageUrl = a.ImageUrl ?? string.Empty
            }).ToList();
        }
    }
}
