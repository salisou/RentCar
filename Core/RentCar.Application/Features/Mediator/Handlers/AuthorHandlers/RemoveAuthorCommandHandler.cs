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

        public Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _authorRepository.GetByIdAsync(request.Id)
                ?? throw new Exception("Author not found");
            if (author.Result != null)
            {
                _authorRepository.RemoveAsync(author.Result);
            }
            return Task.CompletedTask;
        }
    }
}
