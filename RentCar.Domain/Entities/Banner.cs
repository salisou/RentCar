namespace RentCar.Domain.Entities
{
    public class Banner
    {
        public int BannerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoDescription { get; set; } = string.Empty;
        public string VideoUrl { get; set; } = string.Empty;
    }
}
