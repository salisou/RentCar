﻿namespace RentCar.Application.Features.Mediator.Results.AuthorResults
{
    public class GetAuthorQueryResult
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
