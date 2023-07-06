using MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly List<User> User;
        
        public ActionResult Index()
        {
            List<User> users = User;
            return View(users);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Assign a new unique Id for the user (you can replace this with your database logic)
                int newId = User.Max(u => u.Id) + 1;
                user.Id = newId;

                User.Add(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }
        public ActionResult Edit(int id)
        {
            User user = User.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                User existingUser = User.FirstOrDefault(u => u.Id == id);
                if (existingUser == null)
                {
                    return HttpNotFound();
                }

                existingUser.Name = user.Name;

                return RedirectToAction("Index");
            }

            return View(user);
        }
        // GET: User/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    User user = _users.FirstOrDefault(u => u.Id == id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(user);
        //}
        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            User user = User.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                User.Remove(user);
            }

            return RedirectToAction("Index");










        }
    }
}