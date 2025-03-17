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
        }
    }
}
