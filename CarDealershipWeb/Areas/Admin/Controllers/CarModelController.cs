//using AspNetCoreGeneratedDocument;
using CarDealership.DataAccess.Repository.IRepository;
using CarDealership.Models;
using CarDealership.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarDealershipWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarModelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarModelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<CarModel> carModelList = _unitOfWork.CarModel.GetAll(includeProperties: "CarMake").ToList();
            return View(carModelList);
        }

        public IActionResult Upsert(int? id)
        {
            // use a VM instead so we can include CarMakeList dropdown..
            CarModelVM carModelVM = new()
            {
                CarModel = new CarModel(),
                CarMakeList = _unitOfWork.CarMake.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };
            if (id == null || id == 0)
            {
                // no id is passed in, create..
                return View(carModelVM);
            } else
            {
                // if id is passed in, update...
                carModelVM.CarModel = _unitOfWork.CarModel.Get(u => u.Id == id);
                return View(carModelVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CarModelVM carModelVM)
        {
            if (ModelState.IsValid)
            {
                if (carModelVM.CarModel.Id == 0)
                {
                    // create
                    _unitOfWork.CarModel.Add(carModelVM.CarModel);
                    _unitOfWork.Save();
                    TempData["success"] = "New car model added";
                } else
                {
                    // update
                    _unitOfWork.CarModel.Update(carModelVM.CarModel);
                    _unitOfWork.Save();
                    TempData["success"] = "Car model updated";
                }
                return RedirectToAction("Index");
            }

            return View(carModelVM);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            CarModel carModelObj = _unitOfWork.CarModel.Get(u => u.Id == id);
            if (carModelObj == null)
            {
                return NotFound();
            }
            return View(carModelObj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            if (id < 0) { return BadRequest(); }
            CarModel carModelObj = _unitOfWork.CarModel.Get(u=>u.Id == id);
            if (carModelObj == null) { return NotFound(); }
            _unitOfWork.CarModel.Remove(carModelObj);
            _unitOfWork.Save();
            TempData["success"] = "Car model removed";
            return RedirectToAction("Index");
        }
    }
}
