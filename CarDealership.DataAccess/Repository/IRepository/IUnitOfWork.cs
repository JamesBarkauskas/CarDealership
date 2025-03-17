using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICarMakeRepository CarMake { get; }
        void Save();
    }
}
