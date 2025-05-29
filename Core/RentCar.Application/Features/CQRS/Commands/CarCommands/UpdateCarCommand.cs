namespace RentCar.Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateCarCommand
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public int Km { get; set; }
        public string Transmission { get; set; } = string.Empty;
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; } = string.Empty;
        public string BigImageUrl { get; set; } = string.Empty;
    }
}
