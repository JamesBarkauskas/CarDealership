using CarDealership.DataAccess.Repository.IRepository;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Service> serviceList = _unitOfWork.Service.GetAll().ToList();
            return View(serviceList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null)
            {
                return View(new Service());
            }
            else
            {
                Service serviceObj = _unitOfWork.Service.Get(u=>u.Id== id);
                return View(serviceObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Service service)
        {
            if (ModelState.IsValid)
            {
                if (service.Id == 0)
                {
                    _unitOfWork.Service.Add(service);
                    TempData["success"] = "Service added";
                } else
                {
                    _unitOfWork.Service.Update(service);
                    TempData["success"] = "Service updated";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0) { return BadRequest(); }
            Service serviceObj = _unitOfWork.Service.Get(u => u.Id == id);
            if (serviceObj == null) { return NotFound(); }
            return View(serviceObj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            if (id < 0) { return BadRequest(); }
            Service serviceObj = _unitOfWork.Service.Get(u => u.Id == id);
            if (serviceObj == null) { return NotFound(); }
            _unitOfWork.Service.Remove(serviceObj);
            _unitOfWork.Save();
            TempData["success"] = "Service removed";
            return RedirectToAction("Index");
        }
    }
}
