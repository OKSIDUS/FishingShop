using Microsoft.EntityFrameworkCore;
using FishingShop.Services.Database;
using FishingShop.Services.Interfaces;
using FishingShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FishingShopDbContext>((services, options) =>
{
    var configuration = services.GetRequiredService<IConfiguration>();
    options.UseSqlServer(configuration.GetConnectionString("FishingShop"));
});

builder.Services.AddScoped<ITypeOfProductService, TypeOfProductDatabaseService>();
builder.Services.AddScoped<IProductService, ProductService>();

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
