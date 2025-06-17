using MediatR;
using RentCar.Application.Features.Mediator.Commands.CommentCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand>
    {
        private readonly IRepository<Comment> _commentRepository;

        public RemoveCommentCommandHandler(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id)
                ?? throw new ArgumentNullException(nameof(request.Id), "Comment not found");
            await _commentRepository.RemoveAsync(comment);
        }
    }
}
