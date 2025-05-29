namespace RentCar.Application.Features.CQRS.Results.BannerResults
{
    public class BannerByIdQueryResults
    {
        public int BannerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoDescription { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
    }
}
