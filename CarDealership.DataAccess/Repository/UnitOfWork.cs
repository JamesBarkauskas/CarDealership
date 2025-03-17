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
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            CarMake = new CarMakeRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
