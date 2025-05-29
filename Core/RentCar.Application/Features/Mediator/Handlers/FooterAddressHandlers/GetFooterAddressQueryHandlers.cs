using MediatR;
using RentCar.Application.Features.Mediator.Queries.FooterAddressQueries;
using RentCar.Application.Features.Mediator.Results.FooterAddressResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandlers : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repo;

        public GetFooterAddressQueryHandlers(IRepository<FooterAddress> repo)
        {
            _repo = repo;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repo.GetAllAsync()
                .ContinueWith(task => task.Result.Select(x => new GetFooterAddressQueryResult
                {
                    FooterAddressId = x.FooterAddressId,
                    Description = x.Description,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email
                }).ToList(), cancellationToken);
            return values ?? new List<GetFooterAddressQueryResult>();
        }
    }
}
