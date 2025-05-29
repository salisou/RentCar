namespace RentCar.Application.Features.CQRS.Commands.AboutsCommands
{
    public class CreateAboutCommand
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public CreateAboutCommand(string title, string description, string imageUrl)
        {
            Title = title;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
