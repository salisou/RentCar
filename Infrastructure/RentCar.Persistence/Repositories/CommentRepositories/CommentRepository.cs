using Microsoft.EntityFrameworkCore;
using RentCar.Application.Features.RepositoryPattern.CommentRepositories;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly RentCarCaontext _context;

        public CommentRepository(RentCarCaontext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            var values = await _context.Comments.Select(
                c => new Comment
                {
                    CommentId = c.CommentId,
                    BlogId = c.BlogId,
                    BlogCoverImageUrl = c.Blog.CoverImageUrl, // ✅
                    AuthorName = c.AuthorName,
                    CreatedDate = c.CreatedDate,
                    Content = c.Content
                }).ToListAsync();
            return values;
        }

        public async Task<Comment> GetById(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.CommentId == id)
                ?? throw new KeyNotFoundException($"Comment with ID {id} not found.");
        }
        public void Create(Comment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Comment cannot be null.");
            }
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }
        public void Update(Comment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Comment cannot be null.");
            }
            var existingComment = _context.Comments.FirstOrDefault(c => c.CommentId == entity.CommentId);
            if (existingComment == null)
            {
                throw new KeyNotFoundException($"Comment with ID {entity.CommentId} not found.");
            }
            existingComment.AuthorName = entity.Blog.Author.Name;
            existingComment.BlogId = entity.BlogId;
            existingComment.CreatedDate = entity.CreatedDate;
            existingComment.Content = entity.Content;
            _context.SaveChanges();
        }
        public void Delete(Comment entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Comment cannot be null.");
            }
            var existingComment = _context.Comments.FirstOrDefault(c => c.CommentId == entity.CommentId);
            if (existingComment == null)
            {
                throw new KeyNotFoundException($"Comment with ID {entity.CommentId} not found.");
            }
            _context.Comments.Remove(existingComment);
            _context.SaveChanges();
        }
    }
}
