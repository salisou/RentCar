using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.BlogIterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly RentCarCaontext _context;

        public BlogRepository(RentCarCaontext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogsWithAuthors()
        {
            var value = await _context.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync() ?? new();
            return value;
        }

        public async Task<List<Blog>> GetBlogByAuthorId(int id)
        {
            var value = await _context.Blogs
                .Include(b => b.Author)
                .Where(b => b.BlogId == id)
                .ToListAsync() ?? new();
            return value;
        }


        public async Task<List<Blog>> GetLast3BlosWithAuthors()
        {
            var value = await _context.Blogs
                .Include(b => b.Author)
                .Include(b => b.Category)
                .OrderByDescending(b => b.CreatedAt)
                .Take(3)
                .ToListAsync() ?? new();
            return value;
        }
    }
}
