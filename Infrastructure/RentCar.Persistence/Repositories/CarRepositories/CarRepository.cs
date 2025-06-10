using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.CarInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly RentCarCaontext _context;

        public CarRepository(RentCarCaontext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsListWithBrands()
        {
            var value = await _context.Cars
                .Include(x => x.Brand)
                .ToListAsync();
            return value;
        }

        public async Task<List<Car>> GetLast5CarsWithBrands()
        {
            var value = await _context.Cars
                .Include(x => x.Brand)
                .OrderByDescending(x => x.CarId)
                .Take(5)
                .ToListAsync();
            return value;
        }
    }
}
