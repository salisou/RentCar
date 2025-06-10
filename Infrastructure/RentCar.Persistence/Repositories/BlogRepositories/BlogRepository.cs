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

        public List<Blog> GetLast3BlosWithAuthors()
        {
            var values = _context.Blogs
                .Include(x => x.Author)
                .OrderByDescending(x => x.BlogId)
                .Take(3)
                .ToList();
            return values;
        }
    }
}
