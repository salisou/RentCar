using RentCar.Application.Features.CQRS.Handlers.AboutHandlers;
using RentCar.Application.Features.CQRS.Handlers.BannerHandlers;
using RentCar.Application.Features.CQRS.Handlers.BrandHandlers;
using RentCar.Application.Features.CQRS.Handlers.CarHandlers;
using RentCar.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentCar.Application.Features.CQRS.Handlers.ContactHandlers;
using RentCar.Application.Features.RepositoryPattern.CommentRepositories;
using RentCar.Application.Interfaces;
using RentCar.Application.Interfaces.BlogIterfaces;
using RentCar.Application.Interfaces.CarInterfaces;
using RentCar.Application.Interfaces.CarPricingInterfaces;
using RentCar.Application.Interfaces.TagCloudInterfaces;
using RentCar.Persistence.Context;
using RentCar.Persistence.Repositories;
using RentCar.Persistence.Repositories.BlogRepositories;
using RentCar.Persistence.Repositories.CarPricingRepositories;
using RentCar.Persistence.Repositories.CarRepositories;
using RentCar.Persistence.Repositories.CommentRepositories;
using RentCar.Persistence.Repositories.TagCloudRepositories;

public static class ServiceRegistration
{
    public static void AddHandlers(this IServiceCollection services)
    {
        // Add services to the container.
        services.AddScoped<RentCarCaontext>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
        services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
        services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
        services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
        services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));


        services.AddScoped<GetAboutQueryHadler>();
        services.AddScoped<GetAboutByIdQueryHadler>();
        services.AddScoped<CreateAboutCommandHandler>();
        services.AddScoped<UpdateAboutCommandHandler>();
        services.AddScoped<RemoveAboutCommandHandler>();

        services.AddScoped<GetBannerQueryHandler>();
        services.AddScoped<GetBannerByIdQueryHandler>();
        services.AddScoped<CreateBannerCommandHandler>();
        services.AddScoped<UpdateBannerCommandHandler>();
        services.AddScoped<RemoveBannerCommandHandler>();

        services.AddScoped<GetBrandQueryHandler>();
        services.AddScoped<GetBrandByIdQueryHandler>();
        services.AddScoped<CreateBrandCommandHandler>();
        services.AddScoped<UpdateBrandCommandHandler>();
        services.AddScoped<RemoveBrandCommandHandler>();

        services.AddScoped<GetCarQueryHandler>();
        services.AddScoped<GetCarByIdQueryHandler>();
        services.AddScoped<CreateCarCommandHandler>();
        services.AddScoped<UpdateCarCommandHandler>();
        services.AddScoped<RemoveCarCommandHandler>();
        services.AddScoped<GetCarWithBrandQueryHandler>();
        services.AddScoped<GetLast5CarWithBrandQueryHandler>();

        services.AddScoped<GetCategoryQueryHandler>();
        services.AddScoped<GetCategoryByIdQueryHandler>();
        services.AddScoped<CreateCategoryCommandHandler>();
        services.AddScoped<UpdateCategoryCommandHandler>();
        services.AddScoped<RemoveCategoryCommandHandler>();

        services.AddScoped<GetContactQueryHandler>();
        services.AddScoped<GetContactByIdQueryHandler>();
        services.AddScoped<CreateContactCommandHandler>();
        services.AddScoped<UpdateContactCommandHandler>();
        services.AddScoped<RemoveContactCommandHandler>();
    }
}
