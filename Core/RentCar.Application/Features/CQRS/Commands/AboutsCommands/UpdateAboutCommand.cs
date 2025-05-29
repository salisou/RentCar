namespace RentCar.Application.Features.CQRS.Commands.AboutsCommands
{
    public class UpdateAboutCommand
    {
        public int AboutId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public UpdateAboutCommand(int aboutId, string title, string description, string imageUrl)
        {
            AboutId = aboutId;
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
