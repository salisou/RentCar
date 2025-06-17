using MediatR;
using RentCar.Application.Features.Mediator.Commands.AuthorCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IRepository<Author> _authorRepository;

        public CreateAuthorCommandHandler(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name,
                ImageUrl = request.ImageUrl,
                Description = request.Description
            };

            await _authorRepository.CreateAsync(author);
            return author.AuthorId; // ritorna l’ID generato
        }
    }
}
