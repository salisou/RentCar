﻿namespace RentCar.Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommand
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
