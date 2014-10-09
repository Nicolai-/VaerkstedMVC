using Repository.Abstract;
using Repository.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CarController : Controller
    {

        ICarRepository cars;
        // GET: Customer

        public CarController(ICarRepository carRepos)
        {
            this.cars = carRepos;
        }
        [ChildActionOnly]
        // GET: Car
        public ActionResult GetCars(int id = 1)
        {
            IEnumerable<Car> foundCars = cars.GetAllByCustomerId(id);
            return PartialView("_GetCars", foundCars);
        }

        public ActionResult AddCar(int id = 1)
        {
            ViewBag.CustomerId = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddCar(Car car)
        {
            if (ModelState.IsValid)
            {
                cars.Insert(car);
                car = cars.GetById(car.Id);
                return RedirectToAction("CustomerOverview", "Customer", new { id = car.CustomerId });
            }
            ViewBag.CustomerId = car.CustomerId;
            return View();
        }

        public ActionResult EditCar(int id = 1)
        {
            Car foundCar = cars.GetById(id);
            CarVM carVm = new CarVM();
            carVm.Id = foundCar.Id;
            carVm.CustomerId = foundCar.CustomerId;
            carVm.Manufacturer = foundCar.Manufacturer;
            carVm.Model = foundCar.Model;
            carVm.PlateNumber = foundCar.PlateNumber;
            carVm.ChassisNumber = foundCar.ChassisNumber;
            carVm.Year = foundCar.Year;
            return View(carVm);
        }

        [HttpPost]
        public ActionResult EditCar(CarVM car)
        {
            Car carTmp = cars.GetById(car.Id);
            if (ModelState.IsValid)
            {
                carTmp.Manufacturer = car.Manufacturer;
                carTmp.Model = car.Model;
                carTmp.PlateNumber = car.PlateNumber;
                carTmp.ChassisNumber = car.ChassisNumber;
                carTmp.Year = car.Year;
                return RedirectToAction("CustomerOverview", "Customer", carTmp.Customer);
            }
            return View(car);
        }
    }
}