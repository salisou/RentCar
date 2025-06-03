namespace RentCar.Application.Features.Mediator.Results.ServiceResults
{
    public class GetServiceByIdQueryResult
    {
        public int ServiceId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
