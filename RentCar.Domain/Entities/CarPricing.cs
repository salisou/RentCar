namespace RentCar.Domain.Entities
{
    public class CarPricing
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } = new Car();
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; } = new Pricing();
        public decimal Amount { get; set; }
    }
}
