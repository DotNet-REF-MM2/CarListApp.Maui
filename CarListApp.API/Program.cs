using CarListApp.API.Data;
using CarListApp.API.Extensions;
using CarListApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarListApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.ConfigureCors();
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureSqlServerContext(builder.Configuration);


           

            var app = builder.Build();

            // Configure the HTTP request pipeline.


            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<CarListDbContext>();
                DbInitializer.Initialize(context);
            }

            app.UseHttpsRedirection();

           app.MapGet("/cars", async (CarListDbContext db) => await db.Cars.ToListAsync());

            app.MapGet("/cars/{id}", async (int id, CarListDbContext db) =>
                await db.Cars.FindAsync(id) is Car car ? Results.Ok(car) : Results.NotFound()
            );

            app.MapPut("/cars/{id}", async (int id, Car car, CarListDbContext db) => {
                var record = await db.Cars.FindAsync(id);
                if (record is null) return Results.NotFound();

                record.Make = car.Make;
                record.Model = car.Model;
                record.Vin = car.Vin;

                await db.SaveChangesAsync();

                return Results.NoContent();

            });

            app.MapDelete("/cars/{id}", async (int id, CarListDbContext db) => {
                var record = await db.Cars.FindAsync(id);
                if (record is null) return Results.NotFound();
                db.Remove(record);
                await db.SaveChangesAsync();

                return Results.NoContent();

            });

            app.MapPost("/cars", async (Car car, CarListDbContext db) => {
                await db.AddAsync(car);
                await db.SaveChangesAsync();

                return Results.Created($"/cars/{car.Id}", car);

            });




            app.Run();
        }
    }
}