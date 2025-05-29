namespace RentCar.Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand
    {
        public string Name { get; set; }

        public CreateBrandCommand(string name)
        {
            Name = name;
        }
    }
}
