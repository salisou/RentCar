using MediatR;
using RentCar.Application.Features.Mediator.Queries.FooterAddressQueries;
using RentCar.Application.Features.Mediator.Results.FooterAddressResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandlers : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repo;

        public GetFooterAddressByIdQueryHandlers(IRepository<FooterAddress> repo)
        {
            _repo = repo;
        }

        public Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repo.GetByIdAsync(request.Id) ?? throw new Exception("Footer address not found");
            var result = new GetFooterAddressByIdQueryResult
            {
                FooterAddressId = value.Result!.FooterAddressId,
                Description = value.Result.Description,
                Address = value.Result.Address,
                PhoneNumber = value.Result.PhoneNumber,
                Email = value.Result.Email,
            };
            return Task.FromResult(result);
        }
    }
}
