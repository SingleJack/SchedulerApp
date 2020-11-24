using SchedulerApp.Data;
using SchedulerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchedulerApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            List<AdminModel> usersList = new List<AdminModel>();
            AdminDAO adminDAO = new AdminDAO();

            usersList = adminDAO.FetchAll();

            return View("Index", usersList);
        }

        public ActionResult Details(int id)
        {
            AdminDAO adminDAO = new AdminDAO();
            AdminModel user = adminDAO.FetchOne(id);
            return View("Details", user);
        }

        //Display form
        public ActionResult Create()
        {
            return View("CreateForm");
        }

        //Call the CreateOrUpdate function then display details about the new entry
        public ActionResult ProcessCreate(AdminModel adminModel)
        {
            //save to database
            AdminDAO adminDAO = new AdminDAO();
            adminDAO.Create(adminModel);

            return View("Details", adminModel);
        }

        public ActionResult Edit(int id)
        {
            AdminDAO adminDAO = new AdminDAO();
            AdminModel user = adminDAO.FetchOne(id);
            return View("AdminForm", user);
        }

        //Call the CreateOrUpdate function then display details about the new entry
        public ActionResult ProcessEdit(AdminModel adminModel)
        {
            //save to database
            AdminDAO adminDAO = new AdminDAO();
            adminDAO.Update(adminModel);

            return View("Details", adminModel);
        }

        public ActionResult Delete(int id)
        {
            AdminDAO adminDAO = new AdminDAO();
            adminDAO.Delete(id);
            List<AdminModel> users = adminDAO.FetchAll();
            return View("Index", users);
        }
    }
}