using CarDealership.DataAccess.Repository.IRepository;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class NewCarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public NewCarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Car> newCarList = _unitOfWork.Car.GetAll(includeProperties:"CarModel").ToList();
            return View(newCarList);
        }

        public IActionResult Details(int id)
        {
            //TODO:
            // add if conditions to make sure that id exists...
            Car carObj = _unitOfWork.Car.Get(u => u.Id == id, includeProperties:"CarModel");
            return View(carObj);
        }
    }
}
