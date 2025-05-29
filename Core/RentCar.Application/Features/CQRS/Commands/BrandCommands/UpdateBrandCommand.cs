﻿namespace RentCar.Application.Features.CQRS.Commands.BrandCommands
{
    public class UpdateBrandCommand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public UpdateBrandCommand(int brandId, string name)
        {
            BrandId = brandId;
            Name = name;
        }
    }
}
