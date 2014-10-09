using Repository.Abstract;
using Repository.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult GetTasks(int id = 0)
        {
            IEnumerable<Task> foundTasks = tasks.GetAllByCustomerId(id);
            return PartialView("_GetTasks", foundTasks);
        }
    }
}