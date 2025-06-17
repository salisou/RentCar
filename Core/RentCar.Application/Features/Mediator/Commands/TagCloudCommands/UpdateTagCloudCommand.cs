﻿using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class UpdateTagCloudCommand : IRequest
    {
        public int TagCloudId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int BlogId { get; set; }
    }
}
