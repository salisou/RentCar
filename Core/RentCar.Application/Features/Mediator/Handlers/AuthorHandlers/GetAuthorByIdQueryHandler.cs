using MediatR;
using RentCar.Application.Features.Mediator.Queries.AuthorQueries;
using RentCar.Application.Features.Mediator.Results.AuthorResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id)
                .ContinueWith(task =>
                {
                    var author = task.Result;
                    return new GetAuthorByIdQueryResult
                    {
                        AuthorId = author!.AuthorId,
                        Name = author.Name,
                        ImageUrl = author.ImageUrl,
                        Description = author.Description
                    };
                }, cancellationToken);
        }
    }
}
