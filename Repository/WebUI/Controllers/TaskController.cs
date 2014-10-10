using Repository.Abstract;
using Repository.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class TaskController : Controller
    {
        ITaskRepository tasks;
        public TaskController(ITaskRepository taskRepos)
        {
            this.tasks = taskRepos;
        }

        [ChildActionOnly]
        // GET: Task
        public ActionResult GetTasks(int id = 1)
        {
            IEnumerable<Task> foundTasks = tasks.GetAllByCustomerId(id);
            return PartialView("_GetTasks", foundTasks);
        }

        public ActionResult AddTask(int id = 1)
        {
            ViewBag.CarId = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddTask(Task task)
        {
            if (ModelState.IsValid)
            {
                tasks.Insert(task);
                Customer customer = tasks.GetCustomerByCarId(Convert.ToInt32(task.CarId));
                return RedirectToAction("CustomerOverview", "Customer", new { id = customer.Id });
            }
            ViewBag.CarId = task.CarId;            
            return View(task);
        }
    }
}