namespace RentCar.Application.Features.RepositoryPattern.CommentRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetById(int id);
    }
}
