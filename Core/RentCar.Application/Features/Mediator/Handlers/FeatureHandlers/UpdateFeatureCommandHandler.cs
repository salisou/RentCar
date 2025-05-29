using MediatR;
using RentCar.Application.Features.Mediator.Commands.FeatureCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = _repository.GetByIdAsync(request.Id) ?? throw new Exception("Feature not found");
            feature.Result!.Name = request.Name;
            return _repository.UpdateAsync(feature.Result);
        }
    }
}
