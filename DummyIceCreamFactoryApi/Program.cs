using DummyIceCreamFactoryApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IceCreamFactoryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("IceCreamDb")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/ice-creams", async (IceCreamFactoryDbContext dbContext, CancellationToken cancellationToken) =>
{
    dbContext.IceCreams.Add(new IceCream());
    await dbContext.SaveChangesAsync(cancellationToken);

    return await dbContext.IceCreams.ToListAsync(cancellationToken);
}).WithName("GetIceCreams");

app.MapGet("/ice-creams/{id:int}", async Task<Results<Ok<IceCream>, NotFound>> (IceCreamFactoryDbContext dbContext, int id) =>
    await dbContext.FindAsync<IceCream>(id) is { } iceCream
        ? TypedResults.Ok(iceCream)
        : TypedResults.NotFound()
).WithName("GetIceCreamById");

app.Run();

public class IceCreamFactoryDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<IceCream> IceCreams { get; init; }
}