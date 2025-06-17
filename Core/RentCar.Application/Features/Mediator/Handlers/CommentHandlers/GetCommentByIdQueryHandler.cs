using MediatR;
using RentCar.Application.Features.Mediator.Queries.CommentQueries;
using RentCar.Application.Features.Mediator.Results.CommentResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        private readonly IRepository<Comment> _commentRepository;

        public GetCommentByIdQueryHandler(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _commentRepository.GetByIdAsync(request.Id) ?? throw new Exception("Comment not found");
            return new GetCommentByIdQueryResult
            {
                CommentId = value.CommentId,
                AuthorId = value.AuthorId,
                ImageUrl = value.ImageUrl,
                CreatedDate = value.CreatedDate,
                Content = value.Content
            };
        }
    }
}
