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
        ICarModelRepository CarModel { get; }
        ICarRepository Car { get; }
        IServiceRepository Service { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailRepository OrderDetail { get; }
        void Save();
    }
}
