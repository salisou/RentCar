namespace RentCar.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithCarQueryResult
    {
        public int CarPricinId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;
        public string CaverImangeUrl { get; set; } = string.Empty;
    }
}
