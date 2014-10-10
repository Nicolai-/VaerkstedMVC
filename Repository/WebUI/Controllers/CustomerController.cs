using Repository.Abstract;
using Repository.Concrete.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        IGenericRepository<Customer> customers;
        // GET: Customer

        public CustomerController(IGenericRepository<Customer> customerRepos)
        {
            this.customers = customerRepos;
        }

        public ActionResult GetCustomers()
        {
            return View();
        }

        private IEnumerable<Customer> GetData(string searchString)
        {
            IEnumerable<Customer> data = customers.GetAll();
            if (searchString != "")
            {
                searchString = searchString.ToLower();
                data = customers.GetAll().Where(
                    c => c.Name.ToLower().Contains(searchString)
                        || c.Company.ToLower().Contains(searchString)
                        || c.Phone.ToString().Contains(searchString)
                    );
            }
            if (!data.Any())
            {
                data = customers.GetAll();
            }
            return data;
        }

        public JsonResult GetCustomersDataJSON(string searchString)
        {

            //string searchString = ControllerContext.RouteData.Values["searchString"].ToString();
            var data = GetData(searchString).Select(c => new
            {
                Name = c.Name,
                Company = c.Company,
                Phone = c.Phone
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [ChildActionOnly]
        public PartialViewResult GetCustomersData(string searchString = "")
        {
            return PartialView("_GetCustomersData", GetData(searchString));
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customers.Insert(customer);
                return View("GetCustomers");
            }
            return View();
        }

        public ActionResult CustomerOverview(int id = 1)
        {
            Customer customer = customers.GetById(id);
            return View(customer);
        }

    }
}