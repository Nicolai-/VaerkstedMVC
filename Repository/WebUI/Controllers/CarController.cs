using Repository.Abstract;
using Repository.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        // GET: Car
        public ActionResult ViewCars(int id = 1)
        {
            IEnumerable<Car> foundCars = cars.GetAllByCustomerId(id);
            return PartialView(foundCars);
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
                return View("CarAdded", car);
            }
            ViewBag.CustomerId = car.CustomerId;
            return View();
        }
    }
}