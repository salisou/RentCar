using RentCar.Application.Features.CQRS.Queries.ContactQueries;
using RentCar.Application.Features.CQRS.Results.ContactResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult?> Handle(GetContactByIdQuery query)
        {
            Contact? contact = await _repository.GetByIdAsync(query.Id);
            if (contact != null)
            {
                return new GetContactByIdQueryResult
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name ?? string.Empty,
                    Email = contact.Email ?? string.Empty,
                    Subject = contact.Subject ?? string.Empty,
                    Message = contact.Message ?? string.Empty,
                    SendDate = contact.SendDate
                };
            }
            return null;
        }
    }
}
