using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.TagCloudInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly RentCarCaontext _context;

        public TagCloudRepository(RentCarCaontext context)
        {
            _context = context;
        }

        public async Task<List<TagCloud>> GetTagCloudsByBlogId(int blogId)
        {
            if (blogId <= 0)
            {
                throw new ArgumentException("Blog ID must be greater than zero.", nameof(blogId));
            }
            var tagClouds = await _context.Tags
                .Where(tc => tc.BlogId == blogId)
                .ToListAsync();
            if (tagClouds == null || !tagClouds.Any())
            {
                throw new KeyNotFoundException($"No tag clouds found for blog ID {blogId}.");
            }
            return tagClouds;
        }
    }
}
