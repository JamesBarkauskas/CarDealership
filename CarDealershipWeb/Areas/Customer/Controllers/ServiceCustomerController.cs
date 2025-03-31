using CarDealership.DataAccess.Repository.IRepository;
using CarDealership.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Security.Claims;

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

        public IActionResult Schedule(int serviceId)
        {
            ShoppingCart cart = new()
            {
                Service = _unitOfWork.Service.Get(u => u.Id == serviceId),
                ServiceId = serviceId
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Schedule(ShoppingCart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            cart.AppUserId = userId;

            //check if user has a cart for the service already..
            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u=>u.AppUserId == userId &&
            u.ServiceId == cart.ServiceId);

            if (cartFromDb != null)
            {
                // cart exists,
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            } else
            {
                // add cart,
                _unitOfWork.ShoppingCart.Add(cart);
            }
            TempData["success"] = "Cart updated";
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
