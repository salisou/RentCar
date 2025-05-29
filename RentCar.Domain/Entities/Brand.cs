namespace RentCar.Domain.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
        // Navigation property for related Cars
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
