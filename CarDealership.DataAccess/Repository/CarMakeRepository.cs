﻿using CarDealership.DataAccess.Data;
using CarDealership.DataAccess.Repository.IRepository;
using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DataAccess.Repository
{
    public class CarMakeRepository : Repository<CarMake>, ICarMakeRepository
    {
        private readonly AppDbContext _db;
        public CarMakeRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
