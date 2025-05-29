using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RentCarCaontext _context;

        public Repository(RentCarCaontext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
