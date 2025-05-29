using RentCar.Application.Features.CQRS.Results.ContactResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            List<Contact> values = await _repository.GetAllAsync();
            return values.Select(a => new GetContactQueryResult
            {
                ContactId = a.ContactId,
                Name = a.Name,
                Email = a.Email,
                Subject = a.Subject,
                Message = a.Message,
                SendDate = a.SendDate
            }).ToList();
        }
    }
}
