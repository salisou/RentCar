using RentCar.Application.Features.CQRS.Commands.CategoryCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public RemoveCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(RemoveCategoryCommand command)
        {
            var category = await _categoryRepository.GetByIdAsync(command.Id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {command.Id} not found.");
            }
            await _categoryRepository.RemoveAsync(category);
        }
    }
}
