namespace RentCar.Dto.AuthorDtos
{
    public class ResultGetAuthorByBlogAuthorIdDto
    {
        public int AuthorId { get; set; }
        public int BlogId { get; set; }
        public string AuthorImageUrl { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorDescription { get; set; } = string.Empty;
    }
}
