using RentCar.Application.Features.CQRS.Results.CategoryResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new GetCategoryQueryResult
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            }).ToList();
        }
    }
}
