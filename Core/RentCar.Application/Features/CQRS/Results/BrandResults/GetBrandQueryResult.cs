﻿namespace RentCar.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandQueryResult
    {
        public int BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
