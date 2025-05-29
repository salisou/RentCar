﻿using MediatR;
using RentCar.Application.Features.Mediator.Commands.FeatureCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = _repository.GetByIdAsync(request.Id) ?? throw new Exception("Feature not found");
            if (feature.Result != null)
            {
                _repository.RemoveAsync(feature.Result);
            }
            return Task.CompletedTask;
        }
    }
}
