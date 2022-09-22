using CarListApp.API.Models;

namespace CarListApp.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CarListDbContext context)
        {

            context.Database.EnsureCreated();

            // Look for any cars
            if (context.Cars.Any())
            {
                return; // DB has already been seeded
            }

            var cars = new Car[]
                {
                new Car{ Make = "Honda",Model = "Accord",Vin = "abcXIV123"},
                new Car{ Make = "Tesla",Model = "Generation",Vin = "abcXI87123"},
                new Car{ Make = "Ford",Model = "Mustang",Vin = "ab349123" },
                new Car{ Make = "Jeep",Model = "Cherokee",Vin = "gudXIV123"},
                new Car{ Make = "Chrysler",Model = "Acadia",Vin = "px0IV123"},
                new Car{ Make = "Hyundai", Model = "Tourista",Vin = "trip07V123"}
                };
            foreach (Car c in cars)
            {
                context.Cars.Add(c);
            }
            context.SaveChanges();
        }
    }
}
