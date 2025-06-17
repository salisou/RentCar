namespace RentCar.Application.Features.Mediator.Results.CommentResults
{
    public class GetCommentByIdQueryResult
    {
        public int CommentId { get; set; }
        public int AuthorId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Content { get; set; } = string.Empty;
    }
}
