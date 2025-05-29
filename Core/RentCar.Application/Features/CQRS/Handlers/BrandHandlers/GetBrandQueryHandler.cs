using RentCar.Application.Features.CQRS.Results.BrandResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBrandQueryResult>> Handler()
        {
            var brands = await _repository.GetAllAsync();
            var results = brands.Select(b => new GetBrandQueryResult
            {
                BrandId = b.BrandId,
                Name = b.Name
            }).ToList();
            return results;
        }
    }
}
