namespace RentCar.Dto.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public string BlogCoverImageUrl { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
    }
}
