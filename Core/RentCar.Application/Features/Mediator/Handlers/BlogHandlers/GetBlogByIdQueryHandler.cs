using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _blogRepository;

        public GetBlogByIdQueryHandler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetByIdAsync(request.Id)
                .ContinueWith(task =>
                {
                    var blog = task.Result;
                    if (blog == null)
                    {
                        throw new KeyNotFoundException($"Blog with ID {request.Id} not found.");
                    }
                    return new GetBlogByIdQueryResult
                    {
                        BlogId = blog.BlogId,
                        Title = blog.Title,
                        CoverImageUrl = blog.CoverImageUrl,
                        AuthorId = blog.AuthorId,
                        CategoryId = blog.CategoryId,
                        CreatedAt = blog.CreatedAt
                    };
                }, cancellationToken);
        }
    }
}
