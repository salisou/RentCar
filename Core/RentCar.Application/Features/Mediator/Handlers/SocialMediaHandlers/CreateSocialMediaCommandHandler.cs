using MediatR;
using RentCar.Application.Features.Mediator.Commands.SocialMediaCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repo;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repo)
        {
            _repo = repo;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _repo.CreateAsync(new SocialMedia
            {
                Name = request.Name,
                Icon = request.Icon,
                Link = request.Link,
                Url = request.Url,
            });
        }
    }
}
