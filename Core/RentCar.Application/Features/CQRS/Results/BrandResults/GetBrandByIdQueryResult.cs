﻿namespace RentCar.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandByIdQueryResult
    {
        public int BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
