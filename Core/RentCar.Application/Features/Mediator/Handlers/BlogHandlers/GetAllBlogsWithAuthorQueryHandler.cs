using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Interfaces.BlogIterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogsWithAuthors();
            var result = blogs.Select(blog => new GetAllBlogsWithAuthorQueryResult
            {
                BlogId = blog.BlogId,
                Title = blog.Title,
                Description = blog.Description,
                AuthorDescription = blog.Author.Description,
                AuthorImageUrl = blog.Author.ImageUrl,
                CoverImageUrl = blog.CoverImageUrl,
                AuthorId = blog.AuthorId,
                AuthorName = blog.Author.Name,
                CategoryId = blog.CategoryId,
                CategoryName = blog.Category.Name,
                CreatedAt = blog.CreatedAt
            }).ToList();
            return result;
        }
    }
}
