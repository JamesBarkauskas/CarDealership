using CarDealership.DataAccess.Repository.IRepository;
using CarDealership.Models;
using CarDealership.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarDealershipWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CarController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Car> carList = _unitOfWork.Car.GetAll(includeProperties:"CarModel").ToList();
            return View(carList);
        }

        public IActionResult Upsert(int? id)
        {
            CarVM carVM = new CarVM()
            {
                Car = new Car(),
                CarModelList = _unitOfWork.CarModel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name + " " + u.Trim,
                    Value = u.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return View(carVM);
            } else
            {
                carVM.Car = _unitOfWork.Car.Get(u => u.Id == id);
                return View(carVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CarVM carVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                // have to set up this method in case user uploads img..
                string wwwRootPath = _webHostEnvironment.WebRootPath;   // path to wwwroot folder
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string carPath = Path.Combine(wwwRootPath, @"images/car");

                    if (!string.IsNullOrEmpty(carVM.Car.ImageUrl))
                    {
                        // if imageUrl already exists and want to update to new img...
                        var oldImagePath = Path.Combine(wwwRootPath, carVM.Car.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    // otherwise if no prior img exists, just insert new img
                    using (var fileStream = new FileStream(Path.Combine(carPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    // assign the obj's imageUrl..
                    carVM.Car.ImageUrl = @"\images\car\" + fileName;
                }

                // file is null..
                if (carVM.Car.Id == 0)
                {
                    // create
                    _unitOfWork.Car.Add(carVM.Car);
                }
                else
                {
                    _unitOfWork.Car.Update(carVM.Car);
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(carVM);
        }

        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            CarVM carVM = new()
            {
                Car = _unitOfWork.Car.Get(u => u.Id == id),
                CarModelList = _unitOfWork.CarModel.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name + " " + u.Trim,
                    Value = u.Id.ToString()
                })
            };
            if (carVM.Car == null) { return NotFound(); }
            else { return View(carVM); }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            CarVM carVM = new()
            {
                Car = _unitOfWork.Car.Get(u => u.Id == id)
                // dont have to set carModelList bc we have it 'ValidateNever'..?
            };
            if (carVM.Car == null) { return NotFound(); }
            else
            {
                // must remove the img too..
                // check if Car obj has an img, then remove img, otherwise skip and jsut remove car...
                if (!string.IsNullOrEmpty(carVM.Car.ImageUrl))
                {
                    var oldImagePath =
                        Path.Combine(_webHostEnvironment.WebRootPath, carVM.Car.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath)) { System.IO.File.Delete(oldImagePath); }
                }

                _unitOfWork.Car.Remove(carVM.Car);
                _unitOfWork.Save();
                TempData["success"] = "Car removed from inventory";
                return RedirectToAction("Index");
            }
        }
    }
}
