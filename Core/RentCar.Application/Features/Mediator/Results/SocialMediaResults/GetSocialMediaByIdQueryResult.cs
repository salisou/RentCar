namespace RentCar.Application.Features.Mediator.Results.SocialMediaResults
{
    public class GetSocialMediaByIdQueryResult
    {
        public int SocialMediaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
    }
}
