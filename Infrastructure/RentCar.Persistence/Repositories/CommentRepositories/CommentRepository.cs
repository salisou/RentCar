using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.CommentInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly RentCarCaontext _context;

        public CommentRepository(RentCarCaontext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllCommentWithAuthors()
        {
            return await _context.Comments
            .Include(c => c.Author)
            .ToListAsync();
        }
    }
}
