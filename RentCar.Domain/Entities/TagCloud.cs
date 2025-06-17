namespace RentCar.Domain.Entities
{
    public class TagCloud
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int BlogId { get; set; }
        public Blog Blog { get; set; } = new Blog();
    }
}
