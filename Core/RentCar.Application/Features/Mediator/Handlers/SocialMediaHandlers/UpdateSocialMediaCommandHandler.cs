using MediatR;
using RentCar.Application.Features.Mediator.Commands.SocialMediaCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repo;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repo.GetByIdAsync(request.SocialMediaId) ??
                 throw new KeyNotFoundException($"SocialMedial with ID {request.SocialMediaId} not found.");

            value.Name = request.Name;
            value.Url = request.Url;
            value.Icon = request.Icon;
            value.Link = request.Link;

            await _repo.UpdateAsync(value);
        }
    }
}
