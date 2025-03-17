using CarDealership.DataAccess.Repository.IRepository;
using CarDealership.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarMakeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarMakeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<CarMake> carMakeList = _unitOfWork.CarMake.GetAll().ToList();
            return View(carMakeList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new CarMake());
            }
            else
            {
                CarMake carMake = _unitOfWork.CarMake.Get(u => u.Id == id);
                return View(carMake);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CarMake carMake)
        {
            if (ModelState.IsValid)
            {
                if (carMake.Id == 0)
                {
                    _unitOfWork.CarMake.Add(carMake);
                    _unitOfWork.Save();
                    TempData["success"] = "Car make added";
                }
                else
                {
                    _unitOfWork.CarMake.Update(carMake);
                    _unitOfWork.Save();
                    TempData["success"] = "Car make updated";
                }

                return RedirectToAction("Index");
            }
            else
            {
                // ModelState not valid...
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            CarMake obj = _unitOfWork.CarMake.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            CarMake carMake = _unitOfWork.CarMake.Get(u => u.Id == id);
            if (carMake == null) { return NotFound(); }
            _unitOfWork.CarMake.Remove(carMake);
            _unitOfWork.Save();
            TempData["success"] = "Car make removed";
            return RedirectToAction("Index");
        }
    }
}
