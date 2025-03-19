using CarDealership.DataAccess.Data;
using CarDealership.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public ICarMakeRepository CarMake { get; private set; }
        public ICarModelRepository CarModel { get; private set; }
        public ICarRepository Car { get; private set; }
        public IServiceRepository Service { get; private set; }
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            CarMake = new CarMakeRepository(_db);
            CarModel = new CarModelRepository(_db);
            Car = new CarRepository(_db);
            Service = new ServiceRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
