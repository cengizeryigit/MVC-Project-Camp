using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager admM = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValues = admM.GetList();
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueAdminRole = new List<SelectListItem>();
            valueAdminRole.Add(new SelectListItem
            {
                Text = "A",
                Value = "A"

            });
            valueAdminRole.Add(new SelectListItem
            {
                Text = "B",
                Value = "B"

            });
            valueAdminRole.Add(new SelectListItem
            {
                Text = "C",
                Value = "C"

            });
            ViewBag.vlc = valueAdminRole;

            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            string encUsername = StaticFunctions.Encrypt(admin.AdminUsername);
            string encPassword = StaticFunctions.Encrypt(admin.AdminPassword);
            admin.AdminUsername = encUsername;
            admin.AdminPassword = encPassword;
            admM.AdminAdd(admin);
            return RedirectToAction("AddAdmin");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueAdminRole = new List<SelectListItem>();
            valueAdminRole.Add(new SelectListItem
            {
                Text = "A",
                Value = "A"

            });
            valueAdminRole.Add(new SelectListItem
            {
                Text = "B",
                Value = "B"

            });
            valueAdminRole.Add(new SelectListItem
            {
                Text = "C",
                Value = "C"

            });
            ViewBag.vlc = valueAdminRole;

            var adminValue = admM.GetByID(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            admM.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}