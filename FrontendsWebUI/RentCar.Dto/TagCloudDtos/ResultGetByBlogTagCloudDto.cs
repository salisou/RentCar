namespace RentCar.Dto.TagCloudDtos
{
    public class ResultGetByBlogTagCloudDto
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int BlogId { get; set; }
    }
}
