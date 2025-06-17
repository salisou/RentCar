namespace RentCar.Application.Features.Mediator.Results.TagCloudResults
{
    public class GetTagCloudQueryResult
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int BlogId { get; set; }
    }
}
