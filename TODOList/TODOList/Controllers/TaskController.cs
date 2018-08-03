using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TODOList.Models;

namespace TODOList.Controllers
{
    public class TaskController : Controller
    {
        [HttpPost]
        public ActionResult Create(Task task)
        {
            if(task == null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var db = new TaskDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var db = new TaskDbContext())
            {
                var task = db.Tasks.Find(id);

                if(task == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                db.Tasks.Remove(task);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var db = new TaskDbContext())
            {
                var task = db.Tasks.Find(id);

                if(task == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(task);
            }
        } 

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var db = new TaskDbContext())
            {
                var task = db.Tasks.Find(id);

                if(task == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(task);
            }
        }

        [HttpPost]
        [Route("task/edit/{id}")]
        public ActionResult ChangeTask(Task task)
        {
            if (task == null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var db = new TaskDbContext())
            {
                db.Tasks.Update(task);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}