namespace RentCar.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public Author Author { get; set; } = new Author();
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<TagCloud> TagClouds { get; set; } = new();
    }
}
