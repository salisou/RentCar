using MediatR;
using RentCar.Application.Features.Mediator.Queries.CommentQueries;
using RentCar.Application.Features.Mediator.Results.CommentResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, List<GetCommentQueryResult>>
    {
        private readonly IRepository<Comment> _commentRepository;

        public GetCommentQueryHandler(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var value = await _commentRepository.GetAllAsync();

            return value.Select(c => new GetCommentQueryResult
            {
                CommentId = c.CommentId,
                AuthorId = c.AuthorId,
                Content = c.Content,
                CreatedDate = c.CreatedDate,
                ImageUrl = c.ImageUrl
            }).ToList();
        }
    }
}
