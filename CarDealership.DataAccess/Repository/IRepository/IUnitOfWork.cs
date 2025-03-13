using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        // unitOfWork will contain all our repos..
        // were expecting our actual UnitOfWrok to have the following repos..
        ICarMakeRepository CarMake { get; }

        void Save();
    }
}
