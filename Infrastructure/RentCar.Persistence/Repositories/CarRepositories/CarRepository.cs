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

        public List<Car> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var value = _context.Cars
                .Include(x => x.Brand)
                .OrderByDescending(x => x.CarId)
                .Take(5)
                .ToList();
            return value;
        }
    }
}
