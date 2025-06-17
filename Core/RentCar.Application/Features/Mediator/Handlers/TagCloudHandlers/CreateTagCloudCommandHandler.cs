using MediatR;
using RentCar.Application.Features.Mediator.Commands.TagCloudCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand, Unit>
    {
        private readonly IRepository<TagCloud> _tagCloudRepository;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<Unit> Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            await _tagCloudRepository.CreateAsync(new TagCloud
            {
                Title = request.Title,
                BlogId = request.BlogId
            });
            return Unit.Value;
        }
    }
}
