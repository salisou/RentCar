using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BloagResults;
using RentCar.Application.Interfaces.BlogIterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlosWithAuthorQueryHandler : IRequestHandler<GetLast3BlosWithAuthorQuery, List<GetLast3BlosWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlosWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetLast3BlosWithAuthorQueryResult>> Handle(GetLast3BlosWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3BlosWithAuthors();
            var result = values.Select(b => new GetLast3BlosWithAuthorQueryResult
            {
                BlogId = b.BlogId,
                Title = b.Title,
                AuthorName = b.Author.Name,
                CoverImageUrl = b.CoverImageUrl,
                AuthorId = b.AuthorId,
                CategoryId = b.CategoryId,
                CreatedAt = b.CreatedAt
            }).ToList();
            return Task.FromResult(result);
        }
    }
}
