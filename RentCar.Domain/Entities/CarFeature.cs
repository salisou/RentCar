namespace RentCar.Domain.Entities
{
    public class CarFeature
    {
        public int CarFeatureId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } = new Car();
        public int FeatureId { get; set; }
        public Feature Feature { get; set; } = new Feature();
        public bool Available { get; set; }
    }
}
