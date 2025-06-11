using MediatR;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;
using RentCar.Application.Features.Mediator.Results.BlogResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _blogRepository;

        public GetBlogQueryHandler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = _blogRepository.GetAllAsync()
                .ContinueWith(x => x.Result.Select(blog => new GetBlogQueryResult
                {
                    BlogId = blog.BlogId,
                    Title = blog.Title,
                    CoverImageUrl = blog.CoverImageUrl,
                    AuthorId = blog.AuthorId,
                    CategoryId = blog.CategoryId,
                    CreatedAt = blog.CreatedAt
                }).ToList(), cancellationToken);
            return await values;
        }
    }
}
