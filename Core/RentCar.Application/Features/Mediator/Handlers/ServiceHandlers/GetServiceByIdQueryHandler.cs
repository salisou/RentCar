using MediatR;
using RentCar.Application.Features.Mediator.Queries.ServiceQueries;
using RentCar.Application.Features.Mediator.Results.ServiceResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                var service = await _repository.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException($"Service with ID {request.Id} not found.");
                return new GetServiceByIdQueryResult
                {
                    ServiceId = service.ServiceId,
                    Title = service.Title,
                    Description = service.Description,
                    ImageUrl = service.ImageUrl
                };
            }, cancellationToken);
        }
    }
}
