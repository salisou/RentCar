using MediatR;
using RentCar.Application.Features.Mediator.Commands.CommentCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IRepository<Comment> _commentRepository;

        public UpdateCommentCommandHandler(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _commentRepository.GetByIdAsync(request.CommentId) ?? throw new Exception("Comment not found");

            value.AuthorId = request.AuthorId;
            value.ImageUrl = request.ImageUrl;
            value.CreatedDate = request.CreatedDate;
            value.Content = request.Content;

            await _commentRepository.UpdateAsync(value);
        }
    }
}
