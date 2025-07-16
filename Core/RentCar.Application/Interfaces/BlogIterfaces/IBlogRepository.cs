using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.BlogIterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlosWithAuthors();
        Task<List<Blog>> GetAllBlogsWithAuthors();
        Task<List<Blog>> GetBlogByAuthorId(int authorId);
    }
}
