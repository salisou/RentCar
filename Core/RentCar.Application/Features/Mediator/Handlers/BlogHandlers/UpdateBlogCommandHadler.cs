using MediatR;
using RentCar.Application.Features.Mediator.Commands.BlogCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHadler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _blogRepository;

        public UpdateBlogCommandHadler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _blogRepository.GetByIdAsync(request.BlogId) ??
                throw new KeyNotFoundException("Blog not found");

            value.Title = request.Title;
            value.CoverImageUrl = request.CoverImageUrl;
            value.AuthorId = request.AuthorId;
            value.CategoryId = request.CategoryId;
            value.CreatedAt = request.CreatedAt;

            await _blogRepository.UpdateAsync(value);
        }
    }
}
