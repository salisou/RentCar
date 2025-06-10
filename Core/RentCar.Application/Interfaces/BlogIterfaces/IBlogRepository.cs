using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.BlogIterfaces
{
    public interface IBlogRepository
    {
        public List<Blog> GetLast3BlosWithAuthors();
    }
}
