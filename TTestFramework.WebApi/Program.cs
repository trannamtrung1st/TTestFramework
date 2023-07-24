using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TTestFramework.Core.Entities;
using TTestFramework.Core.Interfaces;
using TTestFramework.Core.Repositories;
using TTestFramework.Core.Services;
using TTestFramework.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MainDbContext>(opt => opt.UseInMemoryDatabase(nameof(TTestFramework)));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<IProductService, ProductService>();

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.MapPost("/api/products", async (
    [FromBody] CreateProductModel model,
    [FromServices] IProductService productService) =>
{
    await productService.CreateProduct(model);

    return Results.NoContent();
})
.WithName("Create product");

app.MapGet("/api/products", async (
    [FromServices] IProductService productService) =>
{
    var models = await productService.GetProducts();

    return Results.Ok(models);
})
.WithName("Get product list");

app.Run();
