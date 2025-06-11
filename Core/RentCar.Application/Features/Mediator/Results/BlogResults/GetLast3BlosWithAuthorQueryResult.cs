namespace RentCar.Application.Features.Mediator.Results.BlogResults
{
    public class GetLast3BlosWithAuthorQueryResult
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
