using DI.Data;
using DI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SuperHeroContext>(options =>
{
    options.UseInMemoryDatabase("SuperHeroDb");
});
builder.Services.AddScoped<IRepo, Repo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.MapGet("/", () => "Welcome to database!");

// Get all SuperHero
app.MapGet("/superhero", (IRepo context) =>
context.GetAllSuperHero<SuperHero>().ToList());

// Get SuperHero by Id
app.MapGet("/superhero/{id}", (IRepo context, int id) =>
{
    var result = context.GetSuperHeroById<SuperHero>(id);
    if (result == null) return Results.NotFound();
    return Results.Ok(result);
});

// Add SuperHero
app.MapPost("/superhero/", (IRepo context, SuperHero hero) =>
{
    var result = context.AddSuperHero<SuperHero>(hero);
    if (result == null) return Results.BadRequest();
    return Results.Ok(hero);
});

// Update SuperHero by Id
app.MapPut("/superhero/{id}", (IRepo context, SuperHero hero, int id) =>
{
    if (id != hero.Id || id <= 0) return Results.NotFound("Sorry, hero not found.");
    var result = context.UpdateSuperHero<SuperHero>(hero);
    return Results.Ok(hero);
});

// Delete SuperHero by Id
app.MapDelete("/superhero/{id}", (IRepo context, int id) =>
{
    var result = context.GetSuperHeroById<SuperHero>(id);
    if (result == null) return Results.NotFound("Sorry, hero not found.");
    context.DeleteSuperHeroById<SuperHero>(id);
    return Results.Ok(result);
});

app.Run();
