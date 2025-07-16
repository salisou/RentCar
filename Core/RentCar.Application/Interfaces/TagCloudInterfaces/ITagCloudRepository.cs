﻿using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.TagCloudInterfaces
{
    public interface ITagCloudRepository
    {
        Task<List<TagCloud>> GetTagCloudsByBlogId(int blogId);
    }
}
