using MediatR;
using RentCar.Application.Features.Mediator.Commands.TagCloudCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand, Unit>
    {
        private readonly IRepository<TagCloud> _tagCloudRepository;
        private readonly IRepository<Blog> _blogRepository; // Aggiungi il repository per Blog

        public CreateTagCloudCommandHandler(IRepository<TagCloud> tagCloudRepository, IRepository<Blog> blogRepository)
        {
            _tagCloudRepository = tagCloudRepository;
            _blogRepository = blogRepository; // Inizializza il repository per Blog
        }

        public async Task<Unit> Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            // Recupera il Blog esistente
            var blog = await _blogRepository.GetByIdAsync(request.BlogId); // Usa il repository per Blog
            if (blog == null)
            {
                throw new KeyNotFoundException($"Blog with ID {request.BlogId} not found.");
            }

            // Crea il TagCloud associandolo al Blog esistente
            await _tagCloudRepository.CreateAsync(new TagCloud
            {
                Title = request.Title,
                BlogId = request.BlogId,
                Blog = blog // Associa il Blog esistente
            });

            return Unit.Value;
        }
    }
}
