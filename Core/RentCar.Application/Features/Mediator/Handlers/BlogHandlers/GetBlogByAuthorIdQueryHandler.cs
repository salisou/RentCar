using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Interfaces.BlogIterfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            List<Blog> blogs = await _blogRepository.GetBlogByAuthorId(request.AuthorId);
            List<GetBlogByAuthorIdQueryResult> result = blogs.Select(blog => new GetBlogByAuthorIdQueryResult
            {
                AuthorId = blog.AuthorId,
                BlogId = blog.BlogId,
                AuthorName = blog.Author.Name,
                AuthorDescription = blog.Author.Description ?? string.Empty,
                AuthorImageUrl = blog.Author.ImageUrl ?? string.Empty,
            }).ToList();
            return result;
        }
    }
}
