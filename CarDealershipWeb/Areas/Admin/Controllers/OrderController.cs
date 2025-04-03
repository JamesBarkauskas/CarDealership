using CarDealership.DataAccess.Repository.IRepository;
using CarDealership.Models;
using CarDealership.Models.ViewModels;
using CarDealership.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarDealershipWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller   // order management
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public OrderVM OrderVM { get; set; }
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()    // displays all the scheduled service appointments..
        {
            //foreach (var claim in ((ClaimsIdentity)User.Identity).Claims)
            //{
            //    Console.WriteLine($"Claim Tpye: {claim.Type}, Value: {claim.Value}");
            //}
            return View();
        }

        public IActionResult Details(int orderId)
        {
            OrderVM = new()
            {
                OrderHeader = _unitOfWork.OrderHeader.Get(u=>u.Id==orderId, includeProperties:"ApplicationUser"),
                OrderDetail = _unitOfWork.OrderDetail.GetAll(u=>u.OrderHeaderId==orderId, includeProperties:"Service")
            };
            return View(OrderVM);
        }

        #region API CALLS
        // use api calls so we can get json formatted data to use for our dataTables..
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<OrderHeader> orderHeaders;

            if (User.IsInRole(SD.Role_Admin))
            {
                orderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            }
            else
            {
                //if 'customer' is logged in, they can view their appointments, but not other peoples
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                orderHeaders = _unitOfWork.OrderHeader.GetAll(u => u.ApplicationUserId == userId, includeProperties: "ApplicationUser");
            }

            return Json(new { data = orderHeaders });
        }

        #endregion
    }
}
