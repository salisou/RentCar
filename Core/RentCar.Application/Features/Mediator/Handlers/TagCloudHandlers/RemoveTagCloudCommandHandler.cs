using MediatR;
using RentCar.Application.Features.Mediator.Commands.TagCloudCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repo;

        public RemoveTagCloudCommandHandler(IRepository<TagCloud> repo)
        {
            _repo = repo;
        }

        public Task Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
        {
            var tagCloud = _repo.GetByIdAsync(request.Id).Result;
            if (tagCloud == null)
            {
                throw new KeyNotFoundException($"TagCloud with ID {request.Id} not found.");
            }
            _repo.RemoveAsync(tagCloud);
            return Task.CompletedTask; // Assuming the repository handles saving changes internally
        }
    }
}
