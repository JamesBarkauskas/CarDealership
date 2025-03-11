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

        // add Tables to out Db
        DbSet<CarMake> CarMakes { get; set; }

        // seed data into our tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarMake>().HasData(
                new CarMake { Id = 1, Name = "Chevrolet" },
                new CarMake { Id = 2, Name = "Ford" }
                );
        }
    }
}
