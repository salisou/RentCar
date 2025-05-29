namespace RentCar.Domain.Entities
{
    public class CarDescription
    {
        public int CarDescriptionId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } = new Car();
        public string Details { get; set; } = string.Empty;
    }
}
