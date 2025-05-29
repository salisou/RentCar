using RentCar.Application.Features.CQRS.Queries.AboutQueries;
using RentCar.Application.Features.CQRS.Results.AboutResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHadler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHadler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutQueryResult?> Handle(GetAboutByIdQuery aboutByIdQuery)
        {
            About? about = await _repository.GetByIdAsync(aboutByIdQuery.Id);
            if (about != null)
            {
                return new GetAboutQueryResult
                {
                    AboutId = about.AboutId,
                    Title = about.Title ?? string.Empty,
                    Description = about.Description ?? string.Empty,
                    ImageUrl = about.ImageUrl ?? string.Empty
                };
            }
            return null; // Return null if no About entity is found with the given id
        }
    }
}
