using RentCar.Application.Features.CQRS.Commands.CategoryCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public UpdateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = await _categoryRepository.GetByIdAsync(command.CategoryId);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {command.CategoryId} not found.");
            }
            category.Name = command.Name;
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
