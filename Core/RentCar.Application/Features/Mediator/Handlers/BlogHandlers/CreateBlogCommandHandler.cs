using MediatR;
using RentCar.Application.Features.Mediator.Commands.BlogCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Unit>
    {
        private readonly IRepository<Blog> _blogRepository;

        public CreateBlogCommandHandler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Unit> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _blogRepository.CreateAsync(new Blog
            {
                Title = request.Title,
                CoverImageUrl = request.CoverImageUrl,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                Description = request.Description ?? string.Empty,
                CreatedAt = request.CreatedAt
            });
            return Unit.Value;
        }
    }
}
