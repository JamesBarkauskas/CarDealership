using CarDealership.DataAccess.Repository.IRepository;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ServiceCustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceCustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Service> serviceList = _unitOfWork.Service.GetAll().ToList();
            return View(serviceList);
        }

        //public IActionResult Schedule(int id)
        //{

        //}
    }
}
