using MediatR;
using RentCar.Application.Features.Mediator.Commands.AuthorCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IRepository<Author> _authorRepository;

        public RemoveAuthorCommandHandler(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetByIdAsync(request.Id)
                ?? throw new Exception("Author not found");
            await _authorRepository.RemoveAsync(author);
        }
    }
}
