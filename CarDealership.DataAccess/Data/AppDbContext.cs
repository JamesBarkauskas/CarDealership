using CarDealership.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarMake>().HasData(
                new CarMake { Id = 1, Name = "Chevrolet" },
                new CarMake { Id = 2, Name = "Ford" },
                new CarMake { Id = 3, Name = "Toyota" }
                );

            modelBuilder.Entity<CarModel>().HasData(
                new CarModel { Id = 1, Name = "Equinox", Engine = "1.5L 4-cylinder", Trim = "RS", CarMakeId = 1 },
                new CarModel { Id = 2, Name = "Equinox", Engine = "1.5L 4-cylinder", Trim = "Activ", CarMakeId = 1 },
                new CarModel { Id = 3, Name = "Equinox", Engine = "1.5L 4-cylinder", Trim = "LT", CarMakeId = 1 },
                new CarModel { Id = 4, Name = "Silverado 1500", Engine = "TurboMax", Trim = "RST", CarMakeId = 1 },
                new CarModel { Id = 5, Name = "Silverado 1500", Engine = "5.3L V8", Trim = "Trail Boss", CarMakeId = 1 },
                new CarModel { Id = 6, Name = "Silverado 1500", Engine = "TurboMax", Trim = "LT", CarMakeId = 1 }
                );

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    CarModelId = 1,
                    MSRP = 33000,
                    OurPrice = 32000,
                    StockNumber = "25-1000",
                    VIN = "EQ251200",
                    Year = "2025",
                    Color = "Black",
                    Miles = 2,
                    Drivetrain = "AWD"
                },
                new Car
                {
                    Id = 2,
                    CarModelId = 3,
                    MSRP = 28000,
                    OurPrice = 26000,
                    StockNumber = "25-3000",
                    VIN = "EQ253200",
                    Year = "2025",
                    Color = "Silver",
                    Miles = 3,
                    Drivetrain = "FWD"
                },
                new Car
                {
                    Id = 3,
                    CarModelId = 3,
                    MSRP = 28000,
                    OurPrice = 26000,
                    StockNumber = "25-3100",
                    VIN = "EQ254200",
                    Year = "2025",
                    Color = "White",
                    Miles = 2,
                    Drivetrain = "FWD"
                }
                );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, NameOfService = "Oil Change", Price = 69.99 },
                new Service { Id = 2, NameOfService = "Tire Rotation", Price = 39.99 }
                );

        }
    }
}
