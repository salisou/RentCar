using MediatR;
using RentCar.Application.Features.Mediator.Queries.CommentQueries;
using RentCar.Application.Features.Mediator.Results.CommentResults;
using RentCar.Application.Interfaces.CommentInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentByAuthroQueryHandler : IRequestHandler<GetCommentByAuthroQuery, List<GetCommentByAuthroQueryResult>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentByAuthroQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentByAuthroQueryResult>> Handle(GetCommentByAuthroQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllCommentWithAuthors();
            var result = comments.Select(comment => new GetCommentByAuthroQueryResult
            {
                CommentId = comment.CommentId,
                AuthorId = comment.AuthorId,
                AuthorName = comment.Author.Name,
                ImageUrl = comment.ImageUrl,
                CreatedDate = comment.CreatedDate,
                Content = comment.Content
            }).ToList();
            return result;
        }
    }
}
