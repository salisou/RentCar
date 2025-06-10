using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrands();
        Task<List<Car>> GetLast5CarsWithBrands();
    }
}
