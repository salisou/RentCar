using MediatR;
using RentCar.Application.Features.Mediator.Commands.AuthorCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _authorRepository;

        public UpdateAuthorCommandHandler(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _authorRepository.GetByIdAsync(request.AuthorId)
                ?? throw new Exception("Author not found");
            value!.Name = request.Name;
            value.ImageUrl = request.ImageUrl;
            value.Description = request.Description;
            await _authorRepository.UpdateAsync(value);
        }
    }
}
