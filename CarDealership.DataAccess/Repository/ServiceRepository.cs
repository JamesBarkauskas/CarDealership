using CarDealership.DataAccess.Data;
using CarDealership.DataAccess.Repository.IRepository;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DataAccess.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly AppDbContext _db;
        public ServiceRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
