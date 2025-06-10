using RentCar.Application.Interfaces;
using RentCar.Application.Interfaces.BlogIterfaces;
using RentCar.Application.Interfaces.CarInterfaces;
using RentCar.Application.Interfaces.CarPricingInterfaces;
using RentCar.Application.Services;
using RentCar.Persistence.Context;
using RentCar.Persistence.Repositories;
using RentCar.Persistence.Repositories.BlogRepositories;
using RentCar.Persistence.Repositories.CarPricingRepositories;
using RentCar.Persistence.Repositories.CarRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<RentCarCaontext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));

// Registering Handlers
builder.Services.AddHandlers();

builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
