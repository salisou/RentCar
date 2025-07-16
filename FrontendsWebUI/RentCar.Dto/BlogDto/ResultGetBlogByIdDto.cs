namespace RentCar.Dto.BlogDto
{
    public class ResultGetBlogByIdDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CommentCount { get; set; }
    }
}
