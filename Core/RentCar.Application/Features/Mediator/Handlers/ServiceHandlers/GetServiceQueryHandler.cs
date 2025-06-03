using MediatR;
using RentCar.Application.Features.Mediator.Queries.ServiceQueries;
using RentCar.Application.Features.Mediator.Results.ServiceResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                var services = await _repository.GetAllAsync();
                return services.Select(s => new GetServiceQueryResult
                {
                    ServiceId = s.ServiceId,
                    Title = s.Title,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl
                }).ToList();
            }, cancellationToken);
        }
    }
}
