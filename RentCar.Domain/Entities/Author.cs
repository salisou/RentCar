namespace RentCar.Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Blog> Blogs { get; set; } = new();
    }
}
