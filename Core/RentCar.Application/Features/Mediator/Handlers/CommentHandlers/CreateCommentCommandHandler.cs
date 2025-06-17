using MediatR;
using RentCar.Application.Features.Mediator.Commands.CommentCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

public class CreateCommentCommandHandler(IRepository<Comment> commentRepository, IRepository<Author> authorRepository) : IRequestHandler<CreateCommentCommand>
{
    private readonly IRepository<Comment> _commentRepository = commentRepository;
    private readonly IRepository<Author> _authorRepository = authorRepository;

    public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var existingAuthor = await _authorRepository.GetByIdAsync(request.AuthorId)
            ?? throw new ArgumentException($"Author with ID {request.AuthorId} does not exist.");

        await _commentRepository.CreateAsync(new Comment
        {
            AuthorId = existingAuthor.AuthorId,
            Author = existingAuthor,
            ImageUrl = request.ImageUrl,
            CreatedDate = request.CreatedDate,
            Content = request.Content
        });
    }
}
