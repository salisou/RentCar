using MediatR;
using RentCar.Application.Features.Mediator.Commands.SocialMediaCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repo;

        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repo)
        {
            _repo = repo;
        }

        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            SocialMedia? value = await _repo.GetByIdAsync(request.Id);
            await _repo.RemoveAsync(value!);
        }
    }
}
