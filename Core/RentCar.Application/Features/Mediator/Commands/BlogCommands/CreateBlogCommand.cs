using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.BlogCommands
{
    public class CreateBlogCommand : IRequest<Unit>
    {
        public string Title { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
