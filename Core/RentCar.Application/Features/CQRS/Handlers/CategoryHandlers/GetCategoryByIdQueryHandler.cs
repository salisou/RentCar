using RentCar.Application.Features.CQRS.Queries.CategoryQueries;
using RentCar.Application.Features.CQRS.Results.CategoryResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryByIdQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetCategoryByIdQueryResult?> Handle(GetCategoryByIdQuery query)
        {
            var category = await _categoryRepository.GetByIdAsync(query.Id);
            return category != null ? new GetCategoryByIdQueryResult
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            } : null; // or throw an exception if preferred
        }
    }
}
