using RentCar.Application.Features.CQRS.Queries.BrandQueries;
using RentCar.Application.Features.CQRS.Results.BrandResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandByIdQueryResult> Handler(GetBrandByIdQuery getBrandByIdQuery)
        {
            var brand = await _repository.GetByIdAsync(getBrandByIdQuery.Id);
            if (brand == null)
            {
                return null!; // or throw an exception, depending on your error handling strategy
            }
            return new GetBrandByIdQueryResult
            {
                BrandId = brand.BrandId,
                Name = brand.Name,
            };
        }
    }
}
