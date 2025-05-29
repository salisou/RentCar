﻿namespace RentCar.Application.Features.CQRS.Results.ContactResults
{
    public class GetContactQueryResult
    {
        public int ContactId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime SendDate { get; set; }
    }
}
