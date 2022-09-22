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
                context.Cars.RemoveRange(context.Cars);
                context.SaveChanges();
                //return; // DB has already been seeded
            }

            var cars = new Car[]
                {
                    new Car
                    {
                        Make = "Honda",
                        Model = "Fit",
                        Vin = "ABC",
                        Color="Blue"
                    },
                    new Car
                    {
                        Make = "Honda",
                        Model = "Civic",
                        Vin = "ABC2",
                        Color="Green"
                    },
                    new Car
                    {
                        Make = "Honda",
                        Model = "Stream",
                        Vin = "ABC1",
                        Color="Gold"
                    },
                    new Car
                    { 
                        Make = "Jeep",
                        Model = "Cherokee",
                        Vin = "gudXIV123", 
                        Color="Silver"
                    },
                    new Car
                    {
                       Make = "Nissan",
                        Model = "Note",
                        Vin = "ABC4",
                        Color="Blue"
                    },
                    new Car
                    {
                        Make = "Nissan",
                        Model = "Atlas",
                        Vin = "ABC5",
                        Color="Gold"
                    },
                     new Car
                    {
                        Make = "Nissan",
                        Model = "Dualis",
                        Vin = "ABC6",
                        Color="Silver"
                    },
                    new Car
                    {
                        Make = "Nissan",
                        Model = "Murano",
                        Vin = "ABC7",
                        Color="Blue"
                    },
                    new Car
                    { 
                        Make = "Audi",
                        Model = "A5",
                        Vin = "ABC8",
                        Color="Green"
                    },
                    new Car
                    {
                        Make = "BMW",
                        Model = "M3",
                        Vin = "ABC9",
                        Color="White"
                    },
                    new Car
                    {
                        Make = "Jaguar",
                        Model = "F-Pace",
                        Vin = "ABC10",
                        Color="White"
                    }
                };
            foreach (Car c in cars)
            {
                context.Cars.Add(c);
            }
            context.SaveChanges();
        }
    }
}
