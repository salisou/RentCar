using MediatR;
using RentCar.Application.Features.Mediator.Commands.BlogCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHadler : IRequestHandler<RemoveBlogCommand>
    {
        private readonly IRepository<Blog> _blogRepository;

        public RemoveBlogCommandHadler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _blogRepository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException($"Blog with ID {request.Id} not found.");
            await _blogRepository.RemoveAsync(value);
        }
    }
}
