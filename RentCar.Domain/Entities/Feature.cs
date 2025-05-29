namespace RentCar.Domain.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string Name { get; set; } = string.Empty;
        //public string Description { get; set; } = string.Empty;
        //// Navigation property for related Cars
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
