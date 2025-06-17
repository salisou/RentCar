using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.CommentInterfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentWithAuthors();
    }
}
