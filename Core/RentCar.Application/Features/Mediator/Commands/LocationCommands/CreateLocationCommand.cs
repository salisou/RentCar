﻿using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.LocationCommands
{
    public class CreateLocationCommand : IRequest
    {
        public string Name { get; set; } = string.Empty;
    }
}
