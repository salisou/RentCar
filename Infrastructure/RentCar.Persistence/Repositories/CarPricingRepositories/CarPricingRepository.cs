using Microsoft.EntityFrameworkCore;
using RentCar.Application.Interfaces.CarPricingInterfaces;
using RentCar.Domain.Entities;
using RentCar.Persistence.Context;

namespace RentCar.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly RentCarCaontext _context;

        public CarPricingRepository(RentCarCaontext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCars()
        {
            var value = await _context.CarPricings
                .Include(x => x.Car)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Pricing)
                //.Where(cp => cp.PricingId == 3)
                .ToListAsync();
            return value;
        }
    }
}
