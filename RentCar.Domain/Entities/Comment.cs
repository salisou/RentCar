namespace RentCar.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; } = new();
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
    }
}
